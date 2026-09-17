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
            SET NOCOUNT ON;
            UPDATE A SET Finalizado=1
            FROM dbo.Inv_ConActivo A WITH (UPDLOCK,HOLDLOCK)
            JOIN dbo.Inv_Registro R WITH (UPDLOCK,HOLDLOCK) ON R.id=A.IdInventario
            WHERE A.IdInventario=@Id AND A.Grupo=@Group AND A.Conteo=@Number
            AND ISNULL(A.Finalizado,0)=0 AND ISNULL(R.Cerrado,0)=0
            AND NOT EXISTS(SELECT 1 FROM dbo.Inv_ConActivo N WITH (UPDLOCK,HOLDLOCK)
                WHERE N.IdInventario=@Id AND N.Grupo=@Group AND N.Conteo>@Number)
            AND EXISTS(SELECT 1 FROM dbo.Inv_Conteos C WITH (UPDLOCK,HOLDLOCK)
                WHERE C.IdInventario=@Id AND C.Grupo=@Group AND C.NumConteo=@Number)
            AND NOT EXISTS(SELECT 1 FROM dbo.Inv_Conteos C WITH (UPDLOCK,HOLDLOCK)
                WHERE C.IdInventario=@Id AND C.Grupo=@Group AND C.NumConteo=@Number
                AND (CONVERT(decimal(19,4),C.Cuenta) IS NULL OR CONVERT(decimal(19,4),C.Cuenta)<0
                    OR (@Number>=3 AND ISNULL(C.Reconteo,0)=0)))
            IF @@ROWCOUNT<>1 BEGIN SELECT 0; RETURN; END;
            IF LEN(@Group)>1 AND @Number>=4
            BEGIN
                IF EXISTS(SELECT CodArticulo FROM dbo.Inv_Conteos
                    WHERE IdInventario=@Id AND Grupo=@Group AND NumConteo=@Number
                    GROUP BY CodArticulo HAVING COUNT(*)<>1)
                    OR EXISTS(SELECT 1 FROM dbo.Inv_Conteos C WHERE C.IdInventario=@Id AND C.Grupo=@Group AND C.NumConteo=@Number
                        AND (SELECT COUNT(*) FROM dbo.Inv_Inventario I WHERE I.IdInventario=@Id AND I.Codigo=C.CodArticulo
                            AND I.CodProveedor=C.CodProveedor AND ISNULL(I.Unificado,0)=1 AND I.Stock IS NOT NULL AND I.Costo IS NOT NULL)<>1)
                    BEGIN SELECT 0; RETURN; END;
                UPDATE I SET CF=CONVERT(decimal(19,4),C.Cuenta),
                    DF=I.Stock-CONVERT(decimal(19,4),C.Cuenta),
                    DFM=(I.Stock-CONVERT(decimal(19,4),C.Cuenta))*I.Costo
                    FROM dbo.Inv_Inventario I JOIN dbo.Inv_Conteos C
                    ON C.IdInventario=I.IdInventario AND C.CodArticulo=I.Codigo AND C.CodProveedor=I.CodProveedor
                    WHERE C.IdInventario=@Id AND C.Grupo=@Group AND C.NumConteo=@Number;
            END;
            SELECT 1;
            """;
        await using var command = new SqlCommand(sql, connection, transaction) { CommandTimeout = timeout };
        command.Parameters.Add("@Id", SqlDbType.Int).Value = inventory;
        command.Parameters.Add("@Group", SqlDbType.NVarChar, 50).Value = group.Trim();
        command.Parameters.Add("@Number", SqlDbType.Int).Value = number;
        var succeeded = Convert.ToInt32(await command.ExecuteScalarAsync(token)) == 1;
        if (succeeded) await transaction.CommitAsync(token); else await transaction.RollbackAsync(token);
        return succeeded;
    }
}
