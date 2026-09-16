using System.Data;
using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerDriverRepository(string connectionString, int timeout) : IDriverRepository
{
    private const string Columns = "[CodChofer],[Cedula],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Tipo],[Conse_Devoluciones]";
    public async ValueTask<IReadOnlyCollection<Driver>> ListAsync(string? type, CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var command = Command($"SELECT {Columns} FROM [dbo].[Choferes] WHERE (@Type IS NULL OR [Tipo]=@Type) ORDER BY [CodChofer]", connection);
        command.Parameters.Add("@Type", SqlDbType.NVarChar, 20).Value = (object?)type ?? DBNull.Value;
        var result = new List<Driver>();
        await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token)) result.Add(Read(reader));
        return result;
    }
    public async ValueTask<bool> SaveAsync(Driver driver, bool isNew, CancellationToken token)
    {
        var sql = isNew
            ? "INSERT INTO [dbo].[Choferes]([CodChofer],[Cedula],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Tipo],[Conse_Devoluciones]) VALUES(@Code,@Identification,@Name,@Phone,@Order,@Payment,@Deposit,@Expense,@NoVisit,@Email,@Ftp,@Type,@Return)"
            : "UPDATE [dbo].[Choferes] SET [Cedula]=@Identification,[Nombre]=@Name,[Telefono]=@Phone,[Conse_Pedido]=@Order,[Conse_Pagos]=@Payment,[Conse_Deposito]=@Deposit,[Conse_Gastos]=@Expense,[Conse_NoVisita]=@NoVisit,[Correo]=@Email,[FTP]=@Ftp,[Tipo]=@Type,[Conse_Devoluciones]=@Return WHERE [CodChofer]=@Code";
        await using var connection = await OpenAsync(token); await using var command = Command(sql, connection); AddParameters(command, driver);
        return await command.ExecuteNonQueryAsync(token) == 1;
    }
    public async ValueTask<bool> DeleteAsync(string code, CancellationToken token)
    {
        await using var connection = await OpenAsync(token); await using var command = Command("DELETE FROM [dbo].[Choferes] WHERE [CodChofer]=@Code", connection); Add(command, "@Code", 50, code);
        return await command.ExecuteNonQueryAsync(token) == 1;
    }
    private static Driver Read(SqlDataReader r) => new() { Code = Text(r,"CodChofer"), Identification = Text(r,"Cedula"), Name = Text(r,"Nombre"), Phone = Text(r,"Telefono"), OrderSequence = Text(r,"Conse_Pedido"), PaymentSequence = Text(r,"Conse_Pagos"), DepositSequence = Text(r,"Conse_Deposito"), ExpenseSequence = Text(r,"Conse_Gastos"), NoVisitSequence = Text(r,"Conse_NoVisita"), Email = Text(r,"Correo"), FtpPath = Text(r,"FTP"), Type = Text(r,"Tipo"), ReturnSequence = Text(r,"Conse_Devoluciones") };
    private static void AddParameters(SqlCommand c, Driver x) { Add(c,"@Code",50,x.Code); Add(c,"@Identification",50,x.Identification); Add(c,"@Name",200,x.Name); Add(c,"@Phone",50,x.Phone); Add(c,"@Order",50,x.OrderSequence); Add(c,"@Payment",50,x.PaymentSequence); Add(c,"@Deposit",50,x.DepositSequence); Add(c,"@Expense",50,x.ExpenseSequence); Add(c,"@NoVisit",50,x.NoVisitSequence); Add(c,"@Email",254,x.Email); Add(c,"@Ftp",500,x.FtpPath); Add(c,"@Type",20,x.Type); Add(c,"@Return",50,x.ReturnSequence); }
    private static void Add(SqlCommand c,string n,int l,string v)=>c.Parameters.Add(n,SqlDbType.NVarChar,l).Value=v.Trim();
    private static string Text(SqlDataReader r,string n)=>Convert.ToString(r[n])?.Trim()??"";
    private async ValueTask<SqlConnection> OpenAsync(CancellationToken t){var c=new SqlConnection(connectionString);await c.OpenAsync(t);return c;}
    private SqlCommand Command(string sql,SqlConnection c)=>new(sql,c){CommandTimeout=timeout};
}
