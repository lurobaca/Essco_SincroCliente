using System.Data;
using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerSalesAgentRepository(string connectionString, int timeout) : ISalesAgentRepository
{
    private const string Columns = "[CodAgente],[Cedula],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Grupo],[Conse_Devoluciones],[Conse_ClientesNuevos],[Puesto]";

    public async ValueTask<IReadOnlyCollection<SalesAgent>> ListAsync(string? position, CancellationToken token)
    {
        var sql = $"SELECT {Columns} FROM [dbo].[Agentes] WHERE [CodAgente]<>'3' AND (@Position IS NULL OR [Puesto]=@Position) ORDER BY [CodAgente]";
        await using var connection = await OpenAsync(token);
        await using var command = Command(sql, connection);
        command.Parameters.Add("@Position", SqlDbType.NVarChar, 20).Value = (object?)position ?? DBNull.Value;
        var result = new List<SalesAgent>();
        await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token)) result.Add(Read(reader));
        return result;
    }

    public async ValueTask<bool> SaveAsync(SalesAgent agent, bool isNew, CancellationToken token)
    {
        const string names = "[Cedula],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Grupo],[Conse_Devoluciones],[Conse_ClientesNuevos],[Puesto]";
        const string values = "@Identification,@Name,@Phone,@Order,@Payment,@Deposit,@Expense,@NoVisit,@Email,@Ftp,@Group,@Return,@NewCustomer,@Position";
        var sql = isNew
            ? $"INSERT INTO [dbo].[Agentes]([CodAgente],{names}) VALUES(@Code,{values})"
            : "UPDATE [dbo].[Agentes] SET [Cedula]=@Identification,[Nombre]=@Name,[Telefono]=@Phone,[Conse_Pedido]=@Order,[Conse_Pagos]=@Payment,[Conse_Deposito]=@Deposit,[Conse_Gastos]=@Expense,[Conse_NoVisita]=@NoVisit,[Correo]=@Email,[FTP]=@Ftp,[Grupo]=@Group,[Conse_Devoluciones]=@Return,[Conse_ClientesNuevos]=@NewCustomer,[Puesto]=@Position WHERE [CodAgente]=@Code AND [CodAgente]<>'3'";
        await using var connection = await OpenAsync(token);
        await using var command = Command(sql, connection);
        AddParameters(command, agent);
        return await command.ExecuteNonQueryAsync(token) == 1;
    }

    public async ValueTask<bool> DeleteAsync(string code, CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var command = Command("DELETE FROM [dbo].[Agentes] WHERE [CodAgente]=@Code AND [CodAgente]<>'3'", connection);
        Add(command, "@Code", 50, code);
        return await command.ExecuteNonQueryAsync(token) == 1;
    }

    private static SalesAgent Read(SqlDataReader reader) => new()
    {
        Code = Text(reader, "CodAgente"),
        Identification = Text(reader, "Cedula"),
        Name = Text(reader, "Nombre"),
        Phone = Text(reader, "Telefono"),
        OrderSequence = Text(reader, "Conse_Pedido"),
        PaymentSequence = Text(reader, "Conse_Pagos"),
        DepositSequence = Text(reader, "Conse_Deposito"),
        ExpenseSequence = Text(reader, "Conse_Gastos"),
        NoVisitSequence = Text(reader, "Conse_NoVisita"),
        Email = Text(reader, "Correo"),
        FtpPath = Text(reader, "FTP"),
        Group = Text(reader, "Grupo"),
        ReturnSequence = Text(reader, "Conse_Devoluciones"),
        NewCustomerSequence = Text(reader, "Conse_ClientesNuevos"),
        Position = Text(reader, "Puesto")
    };

    private static void AddParameters(SqlCommand command, SalesAgent agent)
    {
        Add(command, "@Code", 50, agent.Code); Add(command, "@Identification", 50, agent.Identification); Add(command, "@Name", 200, agent.Name);
        Add(command, "@Phone", 50, agent.Phone); Add(command, "@Order", 50, agent.OrderSequence); Add(command, "@Payment", 50, agent.PaymentSequence);
        Add(command, "@Deposit", 50, agent.DepositSequence); Add(command, "@Expense", 50, agent.ExpenseSequence); Add(command, "@NoVisit", 50, agent.NoVisitSequence);
        Add(command, "@Email", 254, agent.Email); Add(command, "@Ftp", 500, agent.FtpPath); Add(command, "@Group", 100, agent.Group);
        Add(command, "@Return", 50, agent.ReturnSequence); Add(command, "@NewCustomer", 50, agent.NewCustomerSequence); Add(command, "@Position", 20, agent.Position);
    }

    private static void Add(SqlCommand command, string name, int length, string value) => command.Parameters.Add(name, SqlDbType.NVarChar, length).Value = value.Trim();
    private static string Text(SqlDataReader reader, string name) => Convert.ToString(reader[name])?.Trim() ?? "";
    private async ValueTask<SqlConnection> OpenAsync(CancellationToken token) { var connection = new SqlConnection(connectionString); await connection.OpenAsync(token); return connection; }
    private SqlCommand Command(string sql, SqlConnection connection) => new(sql, connection) { CommandTimeout = timeout };
}
