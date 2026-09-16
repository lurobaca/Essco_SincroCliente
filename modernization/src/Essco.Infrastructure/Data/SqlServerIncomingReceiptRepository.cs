using System.Data;
using System.Text.RegularExpressions;
using Essco.Application.Treasury;
using Essco.Domain.Treasury;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed partial class SqlServerIncomingReceiptRepository(string connectionString, int timeout, string companyDatabase) : IIncomingReceiptRepository
{
    private string Table => $"[{ValidateDatabase(companyDatabase)}].[dbo].[ORCT]";
    public async ValueTask<IReadOnlyCollection<IncomingReceipt>> ListAsync(IncomingReceiptFilter filter, CancellationToken token)
    {
        var conditions = new List<string> { "ISNULL(T0.[Canceled],'N')<>'Y'" };
        await using var connection = await OpenAsync(token); await using var command = Command("", connection);
        if (filter.From is not null) { conditions.Add("T0.[DocDate]>=@From"); command.Parameters.Add("@From", SqlDbType.Date).Value = filter.From.Value.ToDateTime(TimeOnly.MinValue); }
        if (filter.To is not null) { conditions.Add("T0.[DocDate]<DATEADD(day,1,@To)"); command.Parameters.Add("@To", SqlDbType.Date).Value = filter.To.Value.ToDateTime(TimeOnly.MinValue); }
        AddEquals(conditions, command, "T0.[U_BP_COBRADOR]", "@Collector", filter.CollectorCode);
        AddEquals(conditions, command, "T0.[U_NumLiquidacion]", "@Liquidation", filter.LiquidationNumber);
        if (filter.DocNumber is not null) { conditions.Add("T0.[DocNum]=@DocNumber"); command.Parameters.Add("@DocNumber", SqlDbType.Int).Value = filter.DocNumber.Value; }
        if (filter.OnlyUnlinked) conditions.Add("NULLIF(LTRIM(RTRIM(CONVERT(nvarchar(100),T0.[U_NumLiquidacion]))),'') IS NULL");
        command.CommandText = $"SELECT TOP (500) T0.[DocEntry],T0.[DocNum],T0.[DocDate],T0.[DocTotal],T0.[CardCode],T0.[CardName],T0.[U_BP_COBRADOR],T0.[U_NumLiquidacion] FROM {Table} T0 WHERE {string.Join(" AND ", conditions)} ORDER BY T0.[DocDate] DESC,T0.[DocNum] DESC";
        var result = new List<IncomingReceipt>(); await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token)) result.Add(Read(reader)); return result;
    }
    public async ValueTask<IncomingReceipt?> GetAsync(int docEntry, CancellationToken token)
    {
        await using var connection = await OpenAsync(token); await using var command = Command($"SELECT T0.[DocEntry],T0.[DocNum],T0.[DocDate],T0.[DocTotal],T0.[CardCode],T0.[CardName],T0.[U_BP_COBRADOR],T0.[U_NumLiquidacion] FROM {Table} T0 WHERE T0.[DocEntry]=@DocEntry AND ISNULL(T0.[Canceled],'N')<>'Y'", connection);
        command.Parameters.Add("@DocEntry", SqlDbType.Int).Value = docEntry; await using var reader = await command.ExecuteReaderAsync(token); return await reader.ReadAsync(token) ? Read(reader) : null;
    }
    private static IncomingReceipt Read(SqlDataReader r) => new(Convert.ToInt32(r["DocEntry"]), Convert.ToInt32(r["DocNum"]), DateOnly.FromDateTime(Convert.ToDateTime(r["DocDate"])), Convert.ToDecimal(r["DocTotal"]), Text(r,"CardCode"), Text(r,"CardName"), Text(r,"U_BP_COBRADOR"), Text(r,"U_NumLiquidacion"));
    private static string Text(SqlDataReader r,string name)=>Convert.ToString(r[name])?.Trim()??"";
    private static void AddEquals(ICollection<string> c,SqlCommand command,string column,string parameter,string? value){if(string.IsNullOrWhiteSpace(value))return;c.Add($"{column}={parameter}");command.Parameters.Add(parameter,SqlDbType.NVarChar,100).Value=value.Trim();}
    private static string ValidateDatabase(string value){value=value.Trim();if(!DatabaseName().IsMatch(value))throw new InvalidOperationException("El nombre de la base SAP no es válido.");return value;}
    [GeneratedRegex("^[A-Za-z0-9_]+$")] private static partial Regex DatabaseName();
    private async ValueTask<SqlConnection> OpenAsync(CancellationToken token){var connection=new SqlConnection(connectionString);await connection.OpenAsync(token);return connection;}
    private SqlCommand Command(string sql,SqlConnection connection)=>new(sql,connection){CommandTimeout=timeout};
}
