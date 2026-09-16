using System.Data;
using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerBankRepository(string connectionString, int timeout) : IBankRepository
{
    public async ValueTask<IReadOnlyCollection<CompanyBank>> ListAsync(CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var command = Command("SELECT [Codigo],[Nombre],[Cuenta] FROM [dbo].[BancosEssco] ORDER BY [ID] DESC", connection);
        var result = new List<CompanyBank>();
        await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token))
            result.Add(new CompanyBank
            {
                Code = Convert.ToString(reader["Codigo"])?.Trim() ?? "",
                Name = Convert.ToString(reader["Nombre"])?.Trim() ?? "",
                Account = Convert.ToString(reader["Cuenta"])?.Trim() ?? ""
            });
        return result;
    }

    public async ValueTask CreateAsync(CompanyBank bank, CancellationToken token)
    {
        const string sql = "INSERT INTO [dbo].[BancosEssco]([Codigo],[Nombre],[Cuenta]) VALUES(@Code,@Name,@Account)";
        await using var connection = await OpenAsync(token);
        await using var command = Command(sql, connection);
        command.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = bank.Code.Trim();
        command.Parameters.Add("@Name", SqlDbType.NVarChar, 200).Value = bank.Name.Trim();
        command.Parameters.Add("@Account", SqlDbType.NVarChar, 100).Value = bank.Account.Trim();
        await command.ExecuteNonQueryAsync(token);
    }

    public async ValueTask<bool> DeleteAsync(string code, CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var command = Command("DELETE FROM [dbo].[BancosEssco] WHERE [Codigo]=@Code", connection);
        command.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = code.Trim();
        return await command.ExecuteNonQueryAsync(token) > 0;
    }

    private async ValueTask<SqlConnection> OpenAsync(CancellationToken token)
    {
        var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        return connection;
    }

    private SqlCommand Command(string sql, SqlConnection connection) => new(sql, connection) { CommandTimeout = timeout };
}
