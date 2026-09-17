using System.Data;
using Essco.Application.Inventory;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;

public sealed class SqlServerInventoryCountCompletion(string connectionString, int timeout) : IInventoryCountCompletion
{
    public async ValueTask<bool> CompleteAsync(int inventory, string group, int number, CancellationToken token)
    {
        if (inventory <= 0 || number <= 0 || string.IsNullOrWhiteSpace(group)) return false;
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        const string sql = """
            UPDATE A SET Finalizado=1
            FROM dbo.Inv_ConActivo A WITH (UPDLOCK,HOLDLOCK)
            JOIN dbo.Inv_Registro R WITH (UPDLOCK,HOLDLOCK) ON R.id=A.IdInventario
            WHERE A.IdInventario=@Id AND A.Grupo=@Group AND A.Conteo=@Number
            AND ISNULL(A.Finalizado,0)=0 AND ISNULL(R.Cerrado,0)=0
            AND EXISTS(SELECT 1 FROM dbo.Inv_Conteos C WITH (UPDLOCK,HOLDLOCK)
                WHERE C.IdInventario=@Id AND C.Grupo=@Group AND C.NumConteo=@Number)
            AND NOT EXISTS(SELECT 1 FROM dbo.Inv_Conteos C WITH (UPDLOCK,HOLDLOCK)
                WHERE C.IdInventario=@Id AND C.Grupo=@Group AND C.NumConteo=@Number
                AND (TRY_CONVERT(decimal(19,4),NULLIF(LTRIM(RTRIM(CONVERT(nvarchar(100),C.Cuenta))),'')) IS NULL OR TRY_CONVERT(decimal(19,4),C.Cuenta)<0
                    OR (@Number>=3 AND ISNULL(C.Reconteo,0)=0)))
            """;
        await using var command = new SqlCommand(sql, connection, transaction) { CommandTimeout = timeout };
        command.Parameters.Add("@Id", SqlDbType.Int).Value = inventory;
        command.Parameters.Add("@Group", SqlDbType.NVarChar, 50).Value = group.Trim();
        command.Parameters.Add("@Number", SqlDbType.Int).Value = number;
        var succeeded = await command.ExecuteNonQueryAsync(token) == 1;
        if (succeeded) await transaction.CommitAsync(token); else await transaction.RollbackAsync(token);
        return succeeded;
    }
}
