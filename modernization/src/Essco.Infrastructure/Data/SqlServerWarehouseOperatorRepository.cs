using System.Data;
using System.Text;
using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerWarehouseOperatorRepository(string connectionString, int timeout) : IWarehouseOperatorRepository
{
    private const int SectorCount = 20;

    public async ValueTask<IReadOnlyCollection<WarehouseOperator>> ListAsync(CancellationToken token)
    {
        var sectorColumns = string.Join(',', Enumerable.Range(1, SectorCount).Select(x => $"[Sector{x}]"));
        var sql = $"SELECT [CodBodeguero],[Nombre],[Telefono],[Conse_RepCarga],[Conse_RepDevoluciones],[Correo],[FTP],[Puesto],[Cedula],[Usuario],{sectorColumns} FROM [dbo].[Bodegueros] ORDER BY [Nombre]";
        await using var connection = await OpenAsync(token);
        await using var command = Command(sql, connection);
        var result = new List<WarehouseOperator>();
        await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token))
        {
            var sectors = Enumerable.Range(1, SectorCount).Where(x => Convert.ToInt32(reader[$"Sector{x}"]) != 0).ToArray();
            result.Add(new WarehouseOperator
            {
                Code = Text(reader, "CodBodeguero"),
                Name = Text(reader, "Nombre"),
                Phone = Text(reader, "Telefono"),
                LoadSequence = Text(reader, "Conse_RepCarga"),
                ReturnSequence = Text(reader, "Conse_RepDevoluciones"),
                Email = Text(reader, "Correo"),
                FtpPath = Text(reader, "FTP"),
                Position = Text(reader, "Puesto"),
                Identification = Text(reader, "Cedula"),
                Username = Text(reader, "Usuario"),
                Sectors = sectors
            });
        }
        return result;
    }

    public async ValueTask<bool> SaveAsync(WarehouseOperator item, bool isNew, string? newPassword, CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        try
        {
            var columns = new[] { "Nombre", "Telefono", "Conse_RepCarga", "Conse_RepDevoluciones", "Correo", "FTP", "Puesto", "Cedula", "Usuario" };
            var sectorColumns = Enumerable.Range(1, SectorCount).Select(x => $"Sector{x}").ToArray();
            string sql;
            if (isNew)
            {
                var allColumns = new[] { "CodBodeguero" }.Concat(columns).Concat(sectorColumns).Concat(["Clave"]);
                var allParameters = new[] { "@Code" }.Concat(columns.Select(x => $"@{x}")).Concat(sectorColumns.Select(x => $"@{x}")).Concat(["@Password"]);
                sql = $"INSERT INTO [dbo].[Bodegueros]({string.Join(',', allColumns.Select(x => $"[{x}]"))}) VALUES({string.Join(',', allParameters)})";
            }
            else
            {
                var assignments = columns.Concat(sectorColumns).Select(x => $"[{x}]=@{x}").ToList();
                if (!string.IsNullOrEmpty(newPassword)) assignments.Add("[Clave]=@Password");
                sql = $"UPDATE [dbo].[Bodegueros] SET {string.Join(',', assignments)} WHERE [CodBodeguero]=@Code";
            }

            await using var command = Command(sql, connection, transaction);
            AddParameters(command, item, newPassword);
            var changed = await command.ExecuteNonQueryAsync(token);
            if (changed != 1)
            {
                await transaction.RollbackAsync(token);
                return false;
            }

            await using (var clear = Command("DELETE FROM [dbo].[Sectores_autorizados] WHERE [id_bodeguero]=@Code", connection, transaction))
            {
                clear.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = item.Code.Trim();
                await clear.ExecuteNonQueryAsync(token);
            }
            foreach (var sector in item.Sectors.Order())
            {
                await using var add = Command("INSERT INTO [dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES(@Code,@Sector)", connection, transaction);
                add.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = item.Code.Trim();
                add.Parameters.Add("@Sector", SqlDbType.Int).Value = sector;
                await add.ExecuteNonQueryAsync(token);
            }
            await transaction.CommitAsync(token);
            return true;
        }
        catch
        {
            await transaction.RollbackAsync(token);
            throw;
        }
    }

    public async ValueTask<bool> DeleteAsync(string code, CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(token);
        try
        {
            await using (var sectors = Command("DELETE FROM [dbo].[Sectores_autorizados] WHERE [id_bodeguero]=@Code", connection, transaction))
            {
                sectors.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = code.Trim();
                await sectors.ExecuteNonQueryAsync(token);
            }
            await using var warehouseOperator = Command("DELETE FROM [dbo].[Bodegueros] WHERE [CodBodeguero]=@Code", connection, transaction);
            warehouseOperator.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = code.Trim();
            var changed = await warehouseOperator.ExecuteNonQueryAsync(token);
            await transaction.CommitAsync(token);
            return changed == 1;
        }
        catch
        {
            await transaction.RollbackAsync(token);
            throw;
        }
    }

    private static void AddParameters(SqlCommand command, WarehouseOperator item, string? password)
    {
        Add(command, "@Code", 50, item.Code); Add(command, "@Nombre", 200, item.Name); Add(command, "@Telefono", 50, item.Phone);
        Add(command, "@Conse_RepCarga", 50, item.LoadSequence); Add(command, "@Conse_RepDevoluciones", 50, item.ReturnSequence);
        Add(command, "@Correo", 254, item.Email); Add(command, "@FTP", 500, item.FtpPath); Add(command, "@Puesto", 100, item.Position);
        Add(command, "@Cedula", 50, item.Identification); Add(command, "@Usuario", 100, item.Username);
        var selected = item.Sectors.ToHashSet();
        foreach (var sector in Enumerable.Range(1, SectorCount)) command.Parameters.Add($"@Sector{sector}", SqlDbType.Bit).Value = selected.Contains(sector);
        if (password is not null) Add(command, "@Password", 200, password);
    }

    private static void Add(SqlCommand command, string name, int length, string value) => command.Parameters.Add(name, SqlDbType.NVarChar, length).Value = value.Trim();
    private static string Text(SqlDataReader reader, string name) => Convert.ToString(reader[name])?.Trim() ?? "";
    private async ValueTask<SqlConnection> OpenAsync(CancellationToken token) { var connection = new SqlConnection(connectionString); await connection.OpenAsync(token); return connection; }
    private SqlCommand Command(string sql, SqlConnection connection, SqlTransaction? transaction = null) => new(sql, connection, transaction) { CommandTimeout = timeout };
}
