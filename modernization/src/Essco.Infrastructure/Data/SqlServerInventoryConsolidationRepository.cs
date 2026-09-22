using System.Data;
using Essco.Application.Inventory;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;

public sealed class SqlServerInventoryConsolidationRepository(string connectionString, int timeout) : IInventoryConsolidationRepository
{
    public async ValueTask<bool> CreateAsync(InventoryConsolidationRequest request, CancellationToken token)
    {
        if (!request.IsValid) return false;
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        const string sql = """
            SET NOCOUNT ON;
            IF NOT EXISTS(SELECT 1 FROM dbo.Inv_Registro WITH (UPDLOCK,HOLDLOCK) WHERE id=@Id AND ISNULL(Cerrado,0)=0)
                BEGIN SELECT 0; RETURN; END;
            IF EXISTS(SELECT 1 FROM dbo.Inv_Grupos WITH (UPDLOCK,HOLDLOCK) WHERE CodInventario=@Id AND idGrupo=@Group)
                OR EXISTS(SELECT 1 FROM dbo.Inv_Conteos WITH (UPDLOCK,HOLDLOCK) WHERE IdInventario=@Id AND Grupo=@Group)
                OR EXISTS(SELECT 1 FROM dbo.Inv_ConActivo WITH (UPDLOCK,HOLDLOCK) WHERE IdInventario=@Id AND Grupo=@Group)
                OR EXISTS(SELECT 1 FROM dbo.Inv_Inventario WITH (UPDLOCK,HOLDLOCK)
                    WHERE IdInventario=@Id AND CodProveedor=@Supplier AND ISNULL(Unificado,0)=1)
                BEGIN SELECT 0; RETURN; END;
            SELECT DISTINCT idGrupo INTO #Groups FROM dbo.Inv_Grupos WITH (UPDLOCK,HOLDLOCK)
                WHERE CodInventario=@Id AND CodProveedor=@Supplier AND LEN(idGrupo)=1;
            SELECT G.idGrupo,MAX(A.Conteo) Latest INTO #Latest FROM #Groups G
                LEFT JOIN dbo.Inv_ConActivo A WITH (UPDLOCK,HOLDLOCK) ON A.IdInventario=@Id AND A.Grupo=G.idGrupo
                GROUP BY G.idGrupo;
            IF NOT EXISTS(SELECT 1 FROM #Groups)
                OR EXISTS(SELECT 1 FROM #Latest WHERE Latest IS NULL OR Latest<3)
                OR EXISTS(SELECT 1 FROM #Latest L WHERE
                    (SELECT COUNT(*) FROM dbo.Inv_ConActivo A WHERE A.IdInventario=@Id AND A.Grupo=L.idGrupo AND A.Conteo=L.Latest)<>1
                    OR NOT EXISTS(SELECT 1 FROM dbo.Inv_ConActivo A WHERE A.IdInventario=@Id AND A.Grupo=L.idGrupo AND A.Conteo=L.Latest AND A.Finalizado=1)
                    OR NOT EXISTS(SELECT 1 FROM dbo.Inv_Conteos C WHERE C.IdInventario=@Id AND C.Grupo=L.idGrupo AND C.NumConteo=L.Latest AND C.CodProveedor=@Supplier)
                    OR EXISTS(SELECT 1 FROM dbo.Inv_Conteos C WHERE C.IdInventario=@Id AND C.Grupo=L.idGrupo AND C.NumConteo>L.Latest))
                BEGIN SELECT 0; RETURN; END;
            SELECT C.Grupo,C.CodArticulo,C.Descripcion,C.Reconteo,
                CONVERT(decimal(19,4),C.Cuenta) Quantity
                INTO #Source FROM dbo.Inv_Conteos C WITH (UPDLOCK,HOLDLOCK)
                JOIN #Latest L ON L.idGrupo=C.Grupo AND L.Latest=C.NumConteo
                WHERE C.IdInventario=@Id AND C.CodProveedor=@Supplier;
            IF EXISTS(SELECT 1 FROM #Source WHERE Quantity IS NULL OR Quantity<0 OR ISNULL(Reconteo,0)<>1)
                OR EXISTS(SELECT Grupo,CodArticulo FROM #Source GROUP BY Grupo,CodArticulo HAVING COUNT(*)<>1)
                BEGIN SELECT 0; RETURN; END;
            SELECT CodArticulo,MAX(Descripcion) Descripcion,SUM(Quantity) Quantity INTO #Totals FROM #Source GROUP BY CodArticulo;
            IF NOT EXISTS(SELECT 1 FROM #Totals)
                OR EXISTS(SELECT 1 FROM #Totals WHERE Quantity>2147483647)
                OR EXISTS(SELECT 1 FROM #Totals T WHERE
                    (SELECT COUNT(*) FROM dbo.Inv_Inventario I WHERE I.IdInventario=@Id AND I.Codigo=T.CodArticulo)<>1
                    OR NOT EXISTS(SELECT 1 FROM dbo.Inv_Inventario I WHERE I.IdInventario=@Id AND I.Codigo=T.CodArticulo
                        AND I.CodProveedor=@Supplier AND I.Costo IS NOT NULL AND I.Stock IS NOT NULL))
                OR EXISTS(SELECT 1 FROM dbo.Inv_Inventario I WHERE I.IdInventario=@Id AND I.CodProveedor=@Supplier
                    AND NOT EXISTS(SELECT 1 FROM #Totals T WHERE T.CodArticulo=I.Codigo))
                BEGIN SELECT 0; RETURN; END;
            INSERT INTO dbo.Inv_Grupos (CodInventario,idGrupo,Responsable,Acompanante,CodProveedor,NombreProveedor)
                SELECT @Id,@Group,@Responsible,@Companion,@Supplier,MAX(NombreProveedor)
                FROM dbo.Inv_Grupos WHERE CodInventario=@Id AND CodProveedor=@Supplier;
            INSERT INTO dbo.Inv_Conteos (IdInventario,Grupo,NumConteo,CodArticulo,Descripcion,Cuenta,Reconteo,CodProveedor)
                SELECT @Id,@Group,4,T.CodArticulo,T.Descripcion,T.Quantity,
                    CASE WHEN I.Stock<>T.Quantity AND ABS((I.Stock-T.Quantity)*I.Costo)>=@Threshold THEN 0 ELSE 1 END,@Supplier
                FROM #Totals T JOIN dbo.Inv_Inventario I ON I.IdInventario=@Id AND I.Codigo=T.CodArticulo;
            INSERT INTO dbo.Inv_ConActivo (IdInventario,Grupo,Conteo,Finalizado) VALUES (@Id,@Group,4,0);
            UPDATE I SET Unificado=1,CF=T.Quantity,DF=I.Stock-T.Quantity,DFM=(I.Stock-T.Quantity)*I.Costo
                FROM dbo.Inv_Inventario I JOIN #Totals T ON T.CodArticulo=I.Codigo WHERE I.IdInventario=@Id;
            SELECT 1;
            """;
        await using var command = new SqlCommand(sql, connection, transaction) { CommandTimeout = timeout };
        command.Parameters.Add("@Id", SqlDbType.Int).Value = request.Inventory;
        command.Parameters.Add("@Supplier", SqlDbType.NVarChar, 100).Value = request.Supplier.Trim();
        command.Parameters.Add("@Group", SqlDbType.NVarChar, 50).Value = request.Group.Trim();
        command.Parameters.Add("@Responsible", SqlDbType.NVarChar, 200).Value = request.Responsible.Trim();
        command.Parameters.Add("@Companion", SqlDbType.NVarChar, 200).Value = request.Companion?.Trim() ?? "";
        var threshold = command.Parameters.Add("@Threshold", SqlDbType.Decimal);
        threshold.Precision = 19; threshold.Scale = 4; threshold.Value = request.Threshold;
        var succeeded = Convert.ToInt32(await command.ExecuteScalarAsync(token)) == 1;
        if (succeeded) await transaction.CommitAsync(token); else await transaction.RollbackAsync(token);
        return succeeded;
    }
}
public sealed class UnavailableInventoryConsolidationRepository : IInventoryConsolidationRepository
{
    public ValueTask<bool> CreateAsync(InventoryConsolidationRequest request, CancellationToken token) => ValueTask.FromResult(false);
}
