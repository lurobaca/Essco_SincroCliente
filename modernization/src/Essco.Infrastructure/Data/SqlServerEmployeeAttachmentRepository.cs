using System.Data;
using Essco.Application.HumanResources;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerEmployeeAttachmentRepository(string connectionString, int timeout) : IEmployeeAttachmentRepository
{
    public async ValueTask<byte[]?> GetAsync(string employee, string kind, int number, CancellationToken token)
    {
        var (table, owner) = Target(kind);
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        await using var command = Command($"SELECT [Adjunto] FROM [dbo].[{table}] WHERE [{owner}]=@Employee AND [Consecutivo]=@Number", connection, employee, number);
        return await command.ExecuteScalarAsync(token) as byte[];
    }

    public async ValueTask<bool> SaveAsync(string employee, string kind, int number, byte[] content, CancellationToken token)
    {
        if (EmployeeAttachment.Extension(content) is null) return false;
        var (table, owner) = Target(kind);
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        await using var command = Command($"UPDATE [dbo].[{table}] SET [Adjunto]=@Content WHERE [{owner}]=@Employee AND [Consecutivo]=@Number AND ISNULL([Estado],0)=0", connection, employee, number);
        command.Parameters.Add("@Content", SqlDbType.VarBinary, -1).Value = content;
        return await command.ExecuteNonQueryAsync(token) == 1;
    }

    private SqlCommand Command(string sql, SqlConnection connection, string employee, int number)
    {
        var command = new SqlCommand(sql, connection) { CommandTimeout = timeout };
        command.Parameters.Add("@Employee", SqlDbType.NVarChar, 100).Value = employee;
        command.Parameters.Add("@Number", SqlDbType.Int).Value = number;
        return command;
    }

    private static (string Table, string Owner) Target(string kind) => kind switch
    {
        "vacation" => ("Empleado_Vacaciones", "Cedula_Empleado"),
        "disability" => ("Empleado_Incapacidades", "Cedula_Empleado"),
        "loan" => ("Empleado_ValesPrestamos", "CedulaEmpleado"),
        _ => throw new ArgumentException("Tipo de adjunto inválido.", nameof(kind))
    };
}
