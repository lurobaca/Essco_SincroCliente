using System.Data;
using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerNoVisitReasonRepository(string connectionString, int timeout) : INoVisitReasonRepository
{
    public async ValueTask<IReadOnlyCollection<NoVisitReason>> ListAsync(CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var command = Command("SELECT [Codigo],[Razon] FROM [dbo].[Razones_NoVisita] ORDER BY [Codigo]", connection);
        var result = new List<NoVisitReason>();
        await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token))
            result.Add(new NoVisitReason
            {
                Code = Convert.ToInt32(reader["Codigo"]),
                Reason = Convert.ToString(reader["Razon"])?.Trim() ?? ""
            });
        return result;
    }

    public async ValueTask<int> SaveAsync(NoVisitReason reason, CancellationToken token)
    {
        const string insert = "INSERT INTO [dbo].[Razones_NoVisita]([Razon]) OUTPUT INSERTED.[Codigo] VALUES(@Reason)";
        const string update = "UPDATE [dbo].[Razones_NoVisita] SET [Razon]=@Reason WHERE [Codigo]=@Code; SELECT CASE WHEN @@ROWCOUNT=1 THEN @Code ELSE 0 END";
        await using var connection = await OpenAsync(token);
        await using var command = Command(reason.Code == 0 ? insert : update, connection);
        command.Parameters.Add("@Code", SqlDbType.Int).Value = reason.Code;
        command.Parameters.Add("@Reason", SqlDbType.NVarChar, 250).Value = reason.Reason.Trim();
        var code = Convert.ToInt32(await command.ExecuteScalarAsync(token));
        if (code == 0) throw new DBConcurrencyException("La razón de no visita ya no existe.");
        return code;
    }

    public async ValueTask<bool> DeleteAsync(int code, CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var command = Command("DELETE FROM [dbo].[Razones_NoVisita] WHERE [Codigo]=@Code", connection);
        command.Parameters.Add("@Code", SqlDbType.Int).Value = code;
        return await command.ExecuteNonQueryAsync(token) == 1;
    }

    private async ValueTask<SqlConnection> OpenAsync(CancellationToken token)
    {
        var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        return connection;
    }

    private SqlCommand Command(string sql, SqlConnection connection) => new(sql, connection) { CommandTimeout = timeout };
}
