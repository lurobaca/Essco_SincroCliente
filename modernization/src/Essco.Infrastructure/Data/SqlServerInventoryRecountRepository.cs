using System.Data;
using System.Text.Json;
using Essco.Application.Inventory;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;

public sealed class SqlServerInventoryRecountRepository(string connectionString, int timeout) : IInventoryRecountRepository
{
    public async ValueTask<bool> CreateAsync(InventoryRecountRequest request, CancellationToken token)
    {
        if (!request.IsValid) return false;
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        const string sql = """
            SET NOCOUNT ON;
            IF NOT EXISTS(SELECT 1 FROM dbo.Inv_Registro WITH (UPDLOCK,HOLDLOCK)
                WHERE id=@Id AND ISNULL(Cerrado,0)=0)
                BEGIN SELECT 0; RETURN; END;
            IF (SELECT COUNT(*) FROM dbo.Inv_ConActivo WITH (UPDLOCK,HOLDLOCK)
                WHERE IdInventario=@Id AND Grupo=@Group AND Conteo=@Previous)<>1
                OR NOT EXISTS(SELECT 1 FROM dbo.Inv_ConActivo
                WHERE IdInventario=@Id AND Grupo=@Group AND Conteo=@Previous AND Finalizado=1)
                BEGIN SELECT 0; RETURN; END;
            IF EXISTS(SELECT 1 FROM dbo.Inv_ConActivo WITH (UPDLOCK,HOLDLOCK)
                WHERE IdInventario=@Id AND Grupo=@Group AND Conteo>@Previous)
                OR EXISTS(SELECT 1 FROM dbo.Inv_Conteos WITH (UPDLOCK,HOLDLOCK)
                WHERE IdInventario=@Id AND Grupo=@Group AND NumConteo>@Previous)
                BEGIN SELECT 0; RETURN; END;

            SELECT CodArticulo,Descripcion,Cuenta,Reconteo,CodProveedor
            INTO #Source FROM dbo.Inv_Conteos WITH (UPDLOCK,HOLDLOCK)
            WHERE IdInventario=@Id AND Grupo=@Group AND NumConteo=@Previous;
            SELECT CONVERT(nvarchar(100),value) Code INTO #Selected FROM OPENJSON(@Items);
            IF NOT EXISTS(SELECT 1 FROM #Source)
                OR EXISTS(SELECT CodArticulo FROM #Source GROUP BY CodArticulo HAVING COUNT(*)<>1)
                OR EXISTS(SELECT Code FROM #Selected GROUP BY Code HAVING COUNT(*)<>1)
                OR EXISTS(SELECT 1 FROM #Source WHERE ISNULL(Reconteo,0)<>1
                    OR TRY_CONVERT(decimal(19,4),NULLIF(LTRIM(RTRIM(CONVERT(nvarchar(100),Cuenta))),'')) IS NULL
                    OR TRY_CONVERT(decimal(19,4),Cuenta)<0)
                OR EXISTS(SELECT 1 FROM #Selected S WHERE NOT EXISTS(SELECT 1 FROM #Source C WHERE C.CodArticulo=S.Code))
                BEGIN SELECT 0; RETURN; END;

            INSERT INTO dbo.Inv_Conteos
                (IdInventario,Grupo,NumConteo,CodArticulo,Descripcion,Cuenta,Reconteo,CodProveedor)
            SELECT @Id,@Group,@Previous+1,C.CodArticulo,C.Descripcion,
                CASE WHEN S.Code IS NULL THEN TRY_CONVERT(decimal(19,4),C.Cuenta) ELSE 0 END,
                CASE WHEN S.Code IS NULL THEN 1 ELSE 0 END,C.CodProveedor
            FROM #Source C LEFT JOIN #Selected S ON S.Code=C.CodArticulo;
            INSERT INTO dbo.Inv_ConActivo (IdInventario,Grupo,Conteo,Finalizado)
                VALUES (@Id,@Group,@Previous+1,0);
            SELECT 1;
            """;
        await using var command = new SqlCommand(sql, connection, transaction) { CommandTimeout = timeout };
        command.Parameters.Add("@Id", SqlDbType.Int).Value = request.Inventory;
        command.Parameters.Add("@Group", SqlDbType.NVarChar, 50).Value = request.Group.Trim();
        command.Parameters.Add("@Previous", SqlDbType.Int).Value = request.Previous;
        command.Parameters.Add("@Items", SqlDbType.NVarChar, -1).Value = JsonSerializer.Serialize(request.Items.Select(x => x.Trim()));
        var succeeded = Convert.ToInt32(await command.ExecuteScalarAsync(token)) == 1;
        if (succeeded) await transaction.CommitAsync(token); else await transaction.RollbackAsync(token);
        return succeeded;
    }
}
public sealed class UnavailableInventoryRecountRepository : IInventoryRecountRepository
{
    public ValueTask<bool> CreateAsync(InventoryRecountRequest request, CancellationToken token) => ValueTask.FromResult(false);
}
