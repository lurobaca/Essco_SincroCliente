using System.Data;
using System.Globalization;
using Essco.Application.Customers;
using Essco.Domain.Customers;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;
public sealed class SqlServerAccountStatementRepository(string connectionString,int commandTimeoutSeconds):IAccountStatementRepository
{
    public async ValueTask<IReadOnlyCollection<AccountStatementEntry>> GetAsync(DateOnly from,DateOnly to,AccountStatementStatus status,CancellationToken token)
    {
        var balance=status switch{AccountStatementStatus.Pending=>" AND [DocSaldo]>0",AccountStatementStatus.Paid=>" AND [DocSaldo]=0",_=>""};
        var sql=$"""
            SELECT [DocType],[DocNum],[Clave],[Consecutivo],[DocDate],[Receptor_Nombre],[DocTotal],[DocSubTotal],[DocTotalImpuesto],[DocSaldo],[CodigoMoneda],[TipoCambio],[Exoneracion_MontoImpuesto]
            FROM [dbo].[CE_FE] WHERE [Anulado]='0' AND [DocDate]>=@From AND [DocDate]<DATEADD(day,1,@To){balance}
            ORDER BY [DocDate] DESC,[DocNum] DESC;
            """;
        await using var connection=new SqlConnection(connectionString);await connection.OpenAsync(token);await using var command=new SqlCommand(sql,connection){CommandTimeout=commandTimeoutSeconds};
        command.Parameters.Add("@From",SqlDbType.Date).Value=from.ToDateTime(TimeOnly.MinValue);command.Parameters.Add("@To",SqlDbType.Date).Value=to.ToDateTime(TimeOnly.MinValue);
        var result=new List<AccountStatementEntry>();await using var r=await command.ExecuteReaderAsync(token);while(await r.ReadAsync(token))result.Add(new(Text(r,"DocType"),Long(r,"DocNum"),NullableText(r,"Clave"),NullableText(r,"Consecutivo"),Convert.ToDateTime(r["DocDate"],CultureInfo.InvariantCulture),Text(r,"Receptor_Nombre"),Decimal(r,"DocTotal"),Decimal(r,"DocSubTotal"),Decimal(r,"DocTotalImpuesto"),Decimal(r,"DocSaldo"),Text(r,"CodigoMoneda"),Decimal(r,"TipoCambio"),Decimal(r,"Exoneracion_MontoImpuesto")));return result;
    }
    private static string Text(SqlDataReader r,string n)=>Convert.ToString(r[n],CultureInfo.InvariantCulture)?.Trim()??"";
    private static string? NullableText(SqlDataReader r,string n)=>r[n] is DBNull?null:Text(r,n);
    private static long Long(SqlDataReader r,string n)=>Convert.ToInt64(r[n] is DBNull?0:r[n],CultureInfo.InvariantCulture);
    private static decimal Decimal(SqlDataReader r,string n)=>Convert.ToDecimal(r[n] is DBNull?0:r[n],CultureInfo.InvariantCulture);
}
