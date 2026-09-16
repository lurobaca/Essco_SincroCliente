using System.Data;
using System.Globalization;
using Essco.Application.Customers;
using Essco.Domain.Customers;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerCustomerExemptionRepository(string connectionString, int commandTimeoutSeconds) : ICustomerExemptionRepository
{
    private const string Columns = "[id],[CodCliente],[TipoDocumento],[ExoNumero],[NombreInstitucion],[FechaEmision],[FechaVencimiento],[PorcentajeCompra],[Estado]";
    public async ValueTask<IReadOnlyCollection<CustomerExemption>> ListAsync(string customerCode, CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var command = Command($"SELECT {Columns} FROM [dbo].[DocumentosExoneracionDeClientes] WHERE [CodCliente]=@Code ORDER BY [Estado],[FechaVencimiento] DESC", connection);
        command.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = customerCode;
        var result = new List<CustomerExemption>(); await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token)) result.Add(Map(reader)); return result;
    }
    public async ValueTask<CustomerExemption?> GetAsync(long id, CancellationToken token)
    {
        await using var connection = await OpenAsync(token); await using var command = Command($"SELECT {Columns} FROM [dbo].[DocumentosExoneracionDeClientes] WHERE [id]=@Id", connection);
        command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id; await using var reader = await command.ExecuteReaderAsync(token); return await reader.ReadAsync(token) ? Map(reader) : null;
    }
    public async ValueTask<long> SaveAsync(CustomerExemption x, CancellationToken token)
    {
        const string insert = """
            IF EXISTS(SELECT 1 FROM [dbo].[DocumentosExoneracionDeClientes] WITH(UPDLOCK,HOLDLOCK) WHERE [CodCliente]=@Code AND [ExoNumero]=@Number)
                THROW 51003, 'Ya existe ese número de exoneración para el cliente.', 1;
            INSERT INTO [dbo].[DocumentosExoneracionDeClientes]([CodCliente],[TipoDocumento],[ExoNumero],[NombreInstitucion],[FechaEmision],[FechaVencimiento],[PorcentajeCompra],[Estado])
            OUTPUT INSERTED.[id] VALUES(@Code,@Type,@Number,@Institution,@Issued,@Expires,@Percent,0);
            """;
        const string update = """
            UPDATE [dbo].[DocumentosExoneracionDeClientes] SET [TipoDocumento]=@Type,[ExoNumero]=@Number,[NombreInstitucion]=@Institution,[FechaEmision]=@Issued,[FechaVencimiento]=@Expires,[PorcentajeCompra]=@Percent
            WHERE [id]=@Id AND ISNULL([Estado],0)=0; SELECT CASE WHEN @@ROWCOUNT=1 THEN CAST(@Id AS bigint) ELSE CAST(0 AS bigint) END;
            """;
        await using var connection = await OpenAsync(token); await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        await using var command = Command(x.Id == 0 ? insert : update, connection, transaction); Add(command, x); var id = Convert.ToInt64(await command.ExecuteScalarAsync(token), CultureInfo.InvariantCulture);
        if (id == 0) throw new DBConcurrencyException("La exoneración fue modificada o inactivada por otro usuario."); await transaction.CommitAsync(token); return id;
    }
    public async ValueTask<bool> DeactivateAsync(long id, CancellationToken token)
    {
        const string sql = """
            UPDATE [dbo].[DocumentosExoneracionDeClientes] SET [Estado]=1 WHERE [id]=@Id AND ISNULL([Estado],0)=0;
            IF @@ROWCOUNT=1 BEGIN UPDATE [dbo].[ClientesCabysExentos] SET [Estado]=1 WHERE [IdDocExonerado]=@Id AND ISNULL([Estado],0)=0; SELECT 1; END ELSE SELECT 0;
            """;
        await using var connection = await OpenAsync(token); await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token); await using var command = Command(sql, connection, transaction);
        command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id; var changed = Convert.ToInt32(await command.ExecuteScalarAsync(token), CultureInfo.InvariantCulture) == 1; await transaction.CommitAsync(token); return changed;
    }
    public async ValueTask<IReadOnlyCollection<ExemptCabysCode>> ListCabysAsync(long exemptionId, CancellationToken token)
    {
        const string sql = "SELECT [Id],[IdDocExonerado],[CardCode],[CodCabys],[Estado] FROM [dbo].[ClientesCabysExentos] WHERE [IdDocExonerado]=@Id ORDER BY [Estado],[CodCabys]";
        await using var connection = await OpenAsync(token); await using var command = Command(sql, connection); command.Parameters.Add("@Id", SqlDbType.BigInt).Value = exemptionId;
        var result = new List<ExemptCabysCode>(); await using var reader = await command.ExecuteReaderAsync(token); while (await reader.ReadAsync(token)) result.Add(new(Convert.ToInt64(reader["Id"]), Convert.ToInt64(reader["IdDocExonerado"]), Text(reader, "CardCode"), Text(reader, "CodCabys"), Bool(reader, "Estado"))); return result;
    }
    public async ValueTask<bool> AddCabysAsync(long exemptionId, string customerCode, string cabysCode, CancellationToken token)
    {
        const string sql = """
            IF NOT EXISTS(SELECT 1 FROM [dbo].[DocumentosExoneracionDeClientes] WHERE [id]=@Id AND [CodCliente]=@Code AND ISNULL([Estado],0)=0) THROW 51004,'La exoneración no está activa o no pertenece al cliente.',1;
            IF EXISTS(SELECT 1 FROM [dbo].[ClientesCabysExentos] WHERE [IdDocExonerado]=@Id AND [CodCabys]=@Cabys AND ISNULL([Estado],0)=0) SELECT 0;
            ELSE BEGIN INSERT INTO [dbo].[ClientesCabysExentos]([CardCode],[CodCabys],[IdDocExonerado],[Estado]) VALUES(@Code,@Cabys,@Id,0); SELECT 1; END
            """;
        await using var connection = await OpenAsync(token); await using var command = Command(sql, connection); Params(command, exemptionId, customerCode, cabysCode); return Convert.ToInt32(await command.ExecuteScalarAsync(token), CultureInfo.InvariantCulture) == 1;
    }
    public async ValueTask<bool> RemoveCabysAsync(long exemptionId, string cabysCode, CancellationToken token)
    {
        await using var connection = await OpenAsync(token); await using var command = Command("DELETE FROM [dbo].[ClientesCabysExentos] WHERE [IdDocExonerado]=@Id AND [CodCabys]=@Cabys", connection); command.Parameters.Add("@Id", SqlDbType.BigInt).Value = exemptionId; command.Parameters.Add("@Cabys", SqlDbType.NVarChar, 20).Value = cabysCode; return await command.ExecuteNonQueryAsync(token) == 1;
    }
    private async ValueTask<SqlConnection> OpenAsync(CancellationToken token) { var c = new SqlConnection(connectionString); await c.OpenAsync(token); return c; }
    private SqlCommand Command(string sql, SqlConnection c, SqlTransaction? t = null) => new(sql, c, t) { CommandTimeout = commandTimeoutSeconds };
    private static void Params(SqlCommand c, long id, string code, string cabys) { c.Parameters.Add("@Id", SqlDbType.BigInt).Value = id; c.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = code; c.Parameters.Add("@Cabys", SqlDbType.NVarChar, 20).Value = cabys; }
    private static void Add(SqlCommand c, CustomerExemption x) { c.Parameters.Add("@Id", SqlDbType.BigInt).Value = x.Id; c.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = x.CustomerCode; c.Parameters.Add("@Type", SqlDbType.NVarChar, 2).Value = x.DocumentType; c.Parameters.Add("@Number", SqlDbType.NVarChar, 100).Value = x.Number; c.Parameters.Add("@Institution", SqlDbType.NVarChar, 200).Value = x.Institution; c.Parameters.Add("@Issued", SqlDbType.Date).Value = x.IssuedOn.ToDateTime(TimeOnly.MinValue); c.Parameters.Add("@Expires", SqlDbType.Date).Value = x.ExpiresOn.ToDateTime(TimeOnly.MinValue); var p = c.Parameters.Add("@Percent", SqlDbType.Decimal); p.Precision = 18; p.Scale = 4; p.Value = x.PurchasePercent; }
    private static CustomerExemption Map(SqlDataReader r) => new() { Id = Convert.ToInt64(r["id"]), CustomerCode = Text(r, "CodCliente"), DocumentType = Text(r, "TipoDocumento").PadLeft(2, '0'), Number = Text(r, "ExoNumero"), Institution = Text(r, "NombreInstitucion"), IssuedOn = DateOnly.FromDateTime(Convert.ToDateTime(r["FechaEmision"], CultureInfo.InvariantCulture)), ExpiresOn = DateOnly.FromDateTime(Convert.ToDateTime(r["FechaVencimiento"], CultureInfo.InvariantCulture)), PurchasePercent = Convert.ToDecimal(r["PorcentajeCompra"] is DBNull ? 0 : r["PorcentajeCompra"], CultureInfo.InvariantCulture), Inactive = Bool(r, "Estado") };
    private static string Text(SqlDataReader r, string n) => Convert.ToString(r[n], CultureInfo.InvariantCulture)?.Trim() ?? "";
    private static bool Bool(SqlDataReader r, string n) => r[n] is not DBNull && (r[n] is bool b ? b : Convert.ToInt32(r[n], CultureInfo.InvariantCulture) != 0);
}
