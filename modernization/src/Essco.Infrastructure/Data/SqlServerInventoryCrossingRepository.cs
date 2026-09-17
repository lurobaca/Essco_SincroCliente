using System.Data;
using Essco.Application.Inventory;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;

public sealed class SqlServerInventoryCrossingRepository(string connectionString, int timeout) : IInventoryCrossingRepository
{
    public async ValueTask<bool> CrossAsync(int inventory, string group, decimal threshold, CancellationToken token)
    {
        if (inventory <= 0 || string.IsNullOrWhiteSpace(group) || threshold < 0) return false;
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        const string sql = """
            IF NOT EXISTS (SELECT 1 FROM dbo.Inv_Registro WITH (UPDLOCK,HOLDLOCK)
                WHERE id=@Id AND ISNULL(Cerrado,0)=0) SELECT 0;
            ELSE IF (SELECT COUNT(DISTINCT Conteo) FROM dbo.Inv_ConActivo WITH (UPDLOCK,HOLDLOCK)
                WHERE IdInventario=@Id AND Grupo=@Group AND Conteo IN (1,2) AND Finalizado=1)<>2 SELECT 0;
            ELSE IF EXISTS (SELECT 1 FROM dbo.Inv_Conteos WITH (UPDLOCK,HOLDLOCK)
                WHERE IdInventario=@Id AND Grupo=@Group AND NumConteo>=3) SELECT 0;
            ELSE IF EXISTS (SELECT 1 FROM dbo.Inv_ConActivo WHERE IdInventario=@Id AND Grupo=@Group AND Conteo>=3) SELECT 0;
            ELSE
            BEGIN
                SELECT C.CodArticulo, MAX(C.Descripcion) Descripcion, MAX(C.CodProveedor) CodProveedor,
                    MAX(CASE WHEN C.NumConteo=1 THEN CONVERT(decimal(19,4),C.Cuenta) END) C1,
                    MAX(CASE WHEN C.NumConteo=2 THEN CONVERT(decimal(19,4),C.Cuenta) END) C2,
                    SUM(CASE WHEN C.NumConteo=1 THEN 1 ELSE 0 END) N1,
                    SUM(CASE WHEN C.NumConteo=2 THEN 1 ELSE 0 END) N2
                INTO #Counts FROM dbo.Inv_Conteos C WITH (UPDLOCK,HOLDLOCK)
                WHERE C.IdInventario=@Id AND C.Grupo=@Group AND C.NumConteo IN (1,2)
                GROUP BY C.CodArticulo;
                IF NOT EXISTS(SELECT 1 FROM #Counts) OR EXISTS(
                    SELECT 1 FROM #Counts C WHERE N1<>1 OR N2<>1 OR C1 IS NULL OR C2 IS NULL OR C1<0 OR C2<0
                    OR (SELECT COUNT(*) FROM dbo.Inv_Inventario I WHERE I.IdInventario=@Id AND I.Codigo=C.CodArticulo AND I.Costo IS NOT NULL AND I.Stock IS NOT NULL)<>1)
                    SELECT 0;
                ELSE
                BEGIN
                    INSERT INTO dbo.Inv_Conteos (IdInventario,Grupo,NumConteo,CodArticulo,Descripcion,Cuenta,Reconteo,CodProveedor)
                    SELECT @Id,@Group,3,C.CodArticulo,C.Descripcion,
                        CASE WHEN C1<>C2 AND ABS((C1-C2)*I.Costo)>=@Threshold THEN 0 ELSE C1 END,
                        CASE WHEN C1<>C2 AND ABS((C1-C2)*I.Costo)>=@Threshold THEN 0 ELSE 1 END,
                        C.CodProveedor
                    FROM #Counts C JOIN dbo.Inv_Inventario I ON I.IdInventario=@Id AND I.Codigo=C.CodArticulo;
                    UPDATE I SET CF=C.C1,DF=CASE WHEN C1=C2 THEN C1-I.Stock ELSE C1-C2 END,
                        DFM=(CASE WHEN C1=C2 THEN C1-I.Stock ELSE C1-C2 END)*I.Costo
                    FROM dbo.Inv_Inventario I JOIN #Counts C ON I.Codigo=C.CodArticulo WHERE I.IdInventario=@Id;
                    INSERT INTO dbo.Inv_ConActivo (Grupo,Conteo,IdInventario,Finalizado) VALUES(@Group,3,@Id,0);
                    SELECT 1;
                END
            END
            """;
        await using var command = new SqlCommand(sql, connection, transaction) { CommandTimeout = timeout };
        command.Parameters.Add("@Id", SqlDbType.Int).Value = inventory;
        command.Parameters.Add("@Group", SqlDbType.NVarChar, 50).Value = group.Trim();
        var parameter = command.Parameters.Add("@Threshold", SqlDbType.Decimal);
        parameter.Precision = 19; parameter.Scale = 4; parameter.Value = threshold;
        var succeeded = Convert.ToInt32(await command.ExecuteScalarAsync(token)) == 1;
        if (succeeded) await transaction.CommitAsync(token);
        else await transaction.RollbackAsync(token);
        return succeeded;
    }
}
