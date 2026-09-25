using System.Data;
using Essco.Application.HumanResources;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;

public sealed class SqlServerEmployeeBackgroundRepository(string connectionString, int timeout) : IEmployeeBackgroundRepository
{
    /// <summary>Consulta los estudios y convierte el indicador heredado de EnCurso.</summary>
    public async ValueTask<IReadOnlyCollection<EmployeeEducation>> ListEducationAsync(
        string employeeId,
        CancellationToken cancellationToken)
    {
        // WinForms guardaba EnCurso como texto; la base puede devolver "0" o "1" además de bit.
        const string sql = """
            SELECT [Institucion], [Titulo], [Fecha_Ingreso], [Fecha_Salida], [EnCurso], [Grado]
            FROM [dbo].[Empleado_Educacion]
            WHERE [Cedula_Empleado] = @EmployeeId
            ORDER BY [Fecha_Ingreso] DESC;
            """;

        await using var connection = await Open(cancellationToken);
        await using var command = Cmd(sql, connection);
        P(command, "@EmployeeId", 100, employeeId);

        var education = new List<EmployeeEducation>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            education.Add(new EmployeeEducation(
                S(reader, 0),
                S(reader, 1),
                DateOnly.FromDateTime(reader.GetDateTime(2)),
                DateOnly.FromDateTime(reader.GetDateTime(3)),
                ReadInProgress(reader.GetValue(4)),
                S(reader, 5)));
        }

        return education;
    }

    /// <summary>Interpreta únicamente los valores conocidos del indicador EnCurso.</summary>
    internal static bool ReadInProgress(object databaseValue)
    {
        // Conservar los datos históricos sin convertir cualquier texto desconocido a false.
        return databaseValue switch
        {
            bool booleanValue => booleanValue,
            byte numericValue when numericValue == 0 => false,
            byte numericValue when numericValue == 1 => true,
            int numericValue when numericValue == 0 => false,
            int numericValue when numericValue == 1 => true,
            string textValue when textValue.Trim() is "0" or "False" or "false" => false,
            string textValue when textValue.Trim() is "1" or "True" or "true" => true,
            _ => throw new DataException("El indicador EnCurso contiene un valor no reconocido.")
        };
    }
    public async ValueTask<IReadOnlyCollection<EmployeeExperience>> ListExperienceAsync(string id, CancellationToken t) { await using var c = await Open(t); await using var cmd = Cmd("SELECT [CedulaEmpresa],[Empresa],[Puesto],[Fecha_Ingreso],[Fecha_Salida],[Person_Referencia],[Telefono],[Comentarios] FROM [dbo].[Empleado_Experiencia] WHERE [Cedula_Empleado]=@Id ORDER BY [Fecha_Ingreso] DESC", c); P(cmd, "@Id", 100, id); var a = new List<EmployeeExperience>(); await using var r = await cmd.ExecuteReaderAsync(t); while (await r.ReadAsync(t)) a.Add(new(S(r, 0), S(r, 1), S(r, 2), DateOnly.FromDateTime(r.GetDateTime(3)), DateOnly.FromDateTime(r.GetDateTime(4)), S(r, 5), S(r, 6), S(r, 7))); return a; }
    public async ValueTask<bool> AddEducationAsync(string id, EmployeeEducation x, CancellationToken t) { await using var c = await Open(t); await using var cmd = Cmd("INSERT INTO [dbo].[Empleado_Educacion]([Cedula_Empleado],[Institucion],[Fecha_Ingreso],[Fecha_Salida],[EnCurso],[Grado],[Titulo]) VALUES(@Id,@Institution,@From,@To,@Current,@Degree,@Title)", c); P(cmd, "@Id", 100, id); P(cmd, "@Institution", 300, x.Institution); P(cmd, "@Title", 300, x.Title); P(cmd, "@Degree", 100, x.Degree); cmd.Parameters.Add("@From", SqlDbType.Date).Value = x.From.ToDateTime(TimeOnly.MinValue); cmd.Parameters.Add("@To", SqlDbType.Date).Value = x.To.ToDateTime(TimeOnly.MinValue); cmd.Parameters.Add("@Current", SqlDbType.Bit).Value = x.InProgress; return await cmd.ExecuteNonQueryAsync(t) == 1; }
    public async ValueTask<bool> AddExperienceAsync(string id, EmployeeExperience x, CancellationToken t) { await using var c = await Open(t); await using var cmd = Cmd("INSERT INTO [dbo].[Empleado_Experiencia]([Cedula_Empleado],[CedulaEmpresa],[Empresa],[Puesto],[Fecha_Ingreso],[Fecha_Salida],[Person_Referencia],[Telefono],[Comentarios]) VALUES(@Id,@CompanyId,@Company,@Position,@From,@To,@Reference,@Phone,@Comments)", c); P(cmd, "@Id", 100, id); P(cmd, "@CompanyId", 100, x.CompanyId); P(cmd, "@Company", 300, x.Company); P(cmd, "@Position", 200, x.Position); P(cmd, "@Reference", 300, x.Reference); P(cmd, "@Phone", 100, x.Phone); P(cmd, "@Comments", 1000, x.Comments); cmd.Parameters.Add("@From", SqlDbType.Date).Value = x.From.ToDateTime(TimeOnly.MinValue); cmd.Parameters.Add("@To", SqlDbType.Date).Value = x.To.ToDateTime(TimeOnly.MinValue); return await cmd.ExecuteNonQueryAsync(t) == 1; }
    /// <summary>Actualiza una experiencia solo cuando su cédula de empresa identifica una fila única.</summary>
    public async ValueTask<bool> UpdateExperienceAsync(string id, string companyId, EmployeeExperience item, CancellationToken t)
    {
        // El WinForms actualizaba por coincidencia parcial; exigir una clave exacta evita cambios masivos.
        const string sql = """
            UPDATE [dbo].[Empleado_Experiencia]
            SET [Empresa]=@Company, [Puesto]=@Position, [Fecha_Ingreso]=@From,
                [Fecha_Salida]=@To, [Person_Referencia]=@Reference,
                [Telefono]=@Phone, [Comentarios]=@Comments
            WHERE [Cedula_Empleado]=@Id AND [CedulaEmpresa]=@CompanyId
              AND (SELECT COUNT_BIG(*) FROM [dbo].[Empleado_Experiencia]
                   WHERE [Cedula_Empleado]=@Id AND [CedulaEmpresa]=@CompanyId)=1;
            """;

        await using var connection = await Open(t);
        await using var command = Cmd(sql, connection);
        P(command, "@Id", 100, id);
        P(command, "@CompanyId", 100, companyId);
        P(command, "@Company", 300, item.Company);
        P(command, "@Position", 200, item.Position);
        P(command, "@Reference", 300, item.Reference);
        P(command, "@Phone", 100, item.Phone);
        P(command, "@Comments", 1000, item.Comments);
        command.Parameters.Add("@From", SqlDbType.Date).Value = item.From.ToDateTime(TimeOnly.MinValue);
        command.Parameters.Add("@To", SqlDbType.Date).Value = item.To.ToDateTime(TimeOnly.MinValue);
        return await command.ExecuteNonQueryAsync(t) == 1;
    }
    public ValueTask<bool> DeleteEducationAsync(string id, string key, CancellationToken t) => Delete("Empleado_Educacion", "Institucion", id, key, t); public ValueTask<bool> DeleteExperienceAsync(string id, string key, CancellationToken t) => Delete("Empleado_Experiencia", "CedulaEmpresa", id, key, t);
    private async ValueTask<bool> Delete(string table, string keyColumn, string id, string key, CancellationToken t) { await using var c = await Open(t); await using var cmd = Cmd($"DELETE FROM [dbo].[{table}] WHERE [Cedula_Empleado]=@Id AND [{keyColumn}]=@Key", c); P(cmd, "@Id", 100, id); P(cmd, "@Key", 300, key); return await cmd.ExecuteNonQueryAsync(t) > 0; }
    private async ValueTask<SqlConnection> Open(CancellationToken t) { var c = new SqlConnection(connectionString); await c.OpenAsync(t); return c; }
    private SqlCommand Cmd(string s, SqlConnection c) => new(s, c) { CommandTimeout = timeout }; private static void P(SqlCommand c, string n, int z, string? v) => c.Parameters.Add(n, SqlDbType.NVarChar, z).Value = v?.Trim() ?? ""; private static string S(SqlDataReader r, int i) => r.IsDBNull(i) ? "" : Convert.ToString(r.GetValue(i)) ?? "";
}
