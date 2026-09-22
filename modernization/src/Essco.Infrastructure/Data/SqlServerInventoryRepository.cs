using System.Data;
using Essco.Application.Inventory;
using Essco.Domain.Inventory;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;

public sealed class SqlServerInventoryRepository(string connectionString, int timeout) : IInventoryRepository
{
    public async ValueTask<IReadOnlyCollection<PhysicalInventory>> ListAsync(CancellationToken t) { await using var c = await Open(t); await using var cmd = Cmd("SELECT TOP(500) [id],[Fecha],[Titulo],[Comentario],[Cerrado],[InvInicial],[InvFinal],[ENTRADAS],[SALIDAS],[DIFERENCIAS] FROM [dbo].[Inv_Registro] ORDER BY [id] DESC", c); var a = new List<PhysicalInventory>(); await using var r = await cmd.ExecuteReaderAsync(t); while (await r.ReadAsync(t)) a.Add(Map(r)); return a; }
    public async ValueTask<PhysicalInventory?> GetAsync(int id, CancellationToken t) { await using var c = await Open(t); await using var cmd = Cmd("SELECT [id],[Fecha],[Titulo],[Comentario],[Cerrado],[InvInicial],[InvFinal],[ENTRADAS],[SALIDAS],[DIFERENCIAS] FROM [dbo].[Inv_Registro] WHERE [id]=@Id", c); cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id; await using var r = await cmd.ExecuteReaderAsync(t); return await r.ReadAsync(t) ? Map(r) : null; }
    public async ValueTask<IReadOnlyCollection<InventoryItem>> ListItemsAsync(int id, CancellationToken t) { await using var c = await Open(t); await using var cmd = Cmd("SELECT [Codigo],[Descripcion],[CodProveedor],[Stock],[CF],[Costo],[DF],[DFM] FROM [dbo].[Inv_Inventario] WHERE [IdInventario]=@Id ORDER BY [Codigo]", c); cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id; var a = new List<InventoryItem>(); await using var r = await cmd.ExecuteReaderAsync(t); while (await r.ReadAsync(t)) a.Add(new(S(r, "Codigo"), S(r, "Descripcion"), S(r, "CodProveedor"), D(r, "Stock"), D(r, "CF"), D(r, "Costo"), D(r, "DF"), D(r, "DFM"))); return a; }
    public async ValueTask<IReadOnlyCollection<InventoryCount>> ListCountsAsync(int id, string? g, CancellationToken t) { await using var c = await Open(t); await using var cmd = Cmd("SELECT [IdInventario],[Grupo],[NumConteo],[CodArticulo],[Descripcion],[Cuenta],[Reconteo],[CodProveedor] FROM [dbo].[Inv_Conteos] WHERE [IdInventario]=@Id" + (string.IsNullOrWhiteSpace(g) ? "" : " AND [Grupo]=@Group") + " ORDER BY [Grupo],[NumConteo],[CodArticulo]", c); cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id; if (!string.IsNullOrWhiteSpace(g)) P(cmd, "@Group", 50, g); var a = new List<InventoryCount>(); await using var r = await cmd.ExecuteReaderAsync(t); while (await r.ReadAsync(t)) a.Add(new(Convert.ToInt32(r["IdInventario"]), S(r, "Grupo"), Convert.ToInt32(r["NumConteo"]), S(r, "CodArticulo"), S(r, "Descripcion"), D(r, "Cuenta"), B(r, "Reconteo"), S(r, "CodProveedor"))); return a; }
    public async ValueTask<bool> SaveCountAsync(InventoryCount x, CancellationToken t) { await using var c = await Open(t); await using var cmd = Cmd("UPDATE C SET [Cuenta]=@Quantity,[Reconteo]=@Recount FROM [dbo].[Inv_Conteos] C INNER JOIN [dbo].[Inv_Registro] R ON R.[id]=C.[IdInventario] WHERE C.[IdInventario]=@Id AND C.[Grupo]=@Group AND C.[NumConteo]=@Number AND C.[CodArticulo]=@Item AND ISNULL(R.[Cerrado],0)=0 AND NOT EXISTS(SELECT 1 FROM dbo.Inv_ConActivo A WITH (UPDLOCK,HOLDLOCK) WHERE A.IdInventario=C.IdInventario AND A.Grupo=C.Grupo AND A.Conteo=C.NumConteo AND ISNULL(A.Finalizado,0)=1)", c); Dec(cmd, "@Quantity", x.Quantity); cmd.Parameters.Add("@Recount", SqlDbType.Bit).Value = x.Recount; cmd.Parameters.Add("@Id", SqlDbType.Int).Value = x.InventoryId; P(cmd, "@Group", 50, x.Group); cmd.Parameters.Add("@Number", SqlDbType.Int).Value = x.Number; P(cmd, "@Item", 100, x.ItemCode); return await cmd.ExecuteNonQueryAsync(t) == 1; }
    public async ValueTask<IReadOnlyCollection<InventoryGroup>> ListGroupsAsync(int id, CancellationToken t) { await using var c = await Open(t); await using var cmd = Cmd("SELECT [CodInventario],[idGrupo],[Responsable],[Acompanante],[CodProveedor],[NombreProveedor] FROM [dbo].[Inv_Grupos] WHERE [CodInventario]=@Id ORDER BY [idGrupo],[CodProveedor]", c); cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id; var a = new List<InventoryGroup>(); await using var r = await cmd.ExecuteReaderAsync(t); while (await r.ReadAsync(t)) a.Add(new(Convert.ToInt32(r["CodInventario"]), S(r, "idGrupo"), S(r, "Responsable"), S(r, "Acompanante"), S(r, "CodProveedor"), S(r, "NombreProveedor"))); return a; }
    public async ValueTask<bool> SaveGroupAsync(InventoryGroup x, CancellationToken t) { await using var c = await Open(t); const string sql = "INSERT INTO [dbo].[Inv_Grupos]([idGrupo],[Responsable],[Acompanante],[CodProveedor],[NombreProveedor],[CodInventario]) SELECT @Code,@Responsible,@Companion,@Supplier,@SupplierName,@Id WHERE EXISTS(SELECT 1 FROM [dbo].[Inv_Registro] WHERE [id]=@Id AND ISNULL([Cerrado],0)=0) AND NOT EXISTS(SELECT 1 FROM [dbo].[Inv_Grupos] WHERE [CodInventario]=@Id AND [idGrupo]=@Code AND [CodProveedor]=@Supplier)"; await using var cmd = Cmd(sql, c); cmd.Parameters.Add("@Id", SqlDbType.Int).Value = x.InventoryId; P(cmd, "@Code", 50, x.Code); P(cmd, "@Responsible", 200, x.Responsible); P(cmd, "@Companion", 200, x.Companion); P(cmd, "@Supplier", 100, x.SupplierCode); P(cmd, "@SupplierName", 300, x.SupplierName); return await cmd.ExecuteNonQueryAsync(t) == 1; }
    public async ValueTask<bool> DeleteGroupAsync(int id, string code, string supplier, CancellationToken t) { await using var c = await Open(t); const string sql = "DELETE G FROM [dbo].[Inv_Grupos] G INNER JOIN [dbo].[Inv_Registro] R ON R.[id]=G.[CodInventario] WHERE G.[CodInventario]=@Id AND G.[idGrupo]=@Code AND G.[CodProveedor]=@Supplier AND ISNULL(R.[Cerrado],0)=0 AND NOT EXISTS(SELECT 1 FROM [dbo].[Inv_Conteos] C WHERE C.[IdInventario]=G.[CodInventario] AND C.[Grupo]=G.[idGrupo] AND C.[CodProveedor]=G.[CodProveedor] AND ISNULL(C.[Cuenta],0)<>0)"; await using var cmd = Cmd(sql, c); cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id; P(cmd, "@Code", 50, code); P(cmd, "@Supplier", 100, supplier); return await cmd.ExecuteNonQueryAsync(t) == 1; }
    public async ValueTask<bool> CloseAsync(int id, decimal entries, decimal exits, CancellationToken t)
    {
        if (id <= 0) return false;
        await using var c = await Open(t);
        await using var tx = (SqlTransaction)await c.BeginTransactionAsync(IsolationLevel.Serializable, t);
        const string sql = """
         SET NOCOUNT ON;
         IF NOT EXISTS(SELECT 1 FROM dbo.Inv_Registro WITH (UPDLOCK,HOLDLOCK) WHERE id=@Id AND ISNULL(Cerrado,0)=0)
             BEGIN SELECT 0; RETURN; END;
         IF EXISTS(SELECT 1 FROM dbo.Inv_ConActivo WITH (UPDLOCK,HOLDLOCK)
             WHERE IdInventario=@Id AND ISNULL(Finalizado,0)<>1)
             BEGIN SELECT 0; RETURN; END;
         IF NOT EXISTS(SELECT 1 FROM dbo.Inv_Inventario WITH (UPDLOCK,HOLDLOCK) WHERE IdInventario=@Id)
             OR EXISTS(SELECT 1 FROM dbo.Inv_Inventario WHERE IdInventario=@Id
                 AND (ISNULL(Unificado,0)<>1 OR ISNULL(Cerrado,0)<>0 OR CF IS NULL OR CF<0 OR Stock IS NULL OR Costo IS NULL))
             BEGIN SELECT 0; RETURN; END;
         SELECT Grupo,MAX(Conteo) Latest INTO #Latest
             FROM dbo.Inv_ConActivo WITH (UPDLOCK,HOLDLOCK) WHERE IdInventario=@Id AND LEN(Grupo)>1 GROUP BY Grupo;
         IF EXISTS(SELECT 1 FROM #Latest WHERE Latest IS NULL OR Latest<4)
             OR EXISTS(SELECT 1 FROM #Latest L WHERE (SELECT COUNT(*) FROM dbo.Inv_ConActivo A
                 WHERE A.IdInventario=@Id AND A.Grupo=L.Grupo AND A.Conteo=L.Latest AND A.Finalizado=1)<>1)
             BEGIN SELECT 0; RETURN; END;
         SELECT C.CodArticulo,C.CodProveedor,C.Reconteo,
             CONVERT(decimal(19,4),C.Cuenta) Quantity
             INTO #Accepted FROM dbo.Inv_Conteos C WITH (UPDLOCK,HOLDLOCK)
             JOIN #Latest L ON L.Grupo=C.Grupo AND L.Latest=C.NumConteo WHERE C.IdInventario=@Id;
         IF EXISTS(SELECT 1 FROM #Accepted WHERE Quantity IS NULL OR Quantity<0 OR ISNULL(Reconteo,0)<>1)
             OR EXISTS(SELECT CodArticulo FROM #Accepted GROUP BY CodArticulo HAVING COUNT(*)<>1)
             OR EXISTS(SELECT Codigo FROM dbo.Inv_Inventario WHERE IdInventario=@Id GROUP BY Codigo HAVING COUNT(*)<>1)
             OR EXISTS(SELECT 1 FROM dbo.Inv_Inventario I WHERE I.IdInventario=@Id
                 AND NOT EXISTS(SELECT 1 FROM #Accepted A WHERE A.CodArticulo=I.Codigo AND A.CodProveedor=I.CodProveedor AND A.Quantity=I.CF))
             OR EXISTS(SELECT 1 FROM #Accepted A WHERE NOT EXISTS(SELECT 1 FROM dbo.Inv_Inventario I WHERE I.IdInventario=@Id AND I.Codigo=A.CodArticulo))
             BEGIN SELECT 0; RETURN; END;
         UPDATE dbo.Inv_Inventario SET Cerrado=1,DF=Stock-CF,DFM=(Stock-CF)*Costo WHERE IdInventario=@Id;
         UPDATE dbo.Inv_Registro SET Cerrado=1,
             InvFinal=(SELECT SUM(CF*Costo) FROM dbo.Inv_Inventario WHERE IdInventario=@Id),
             ENTRADAS=(SELECT SUM(CASE WHEN CF>Stock THEN (CF-Stock)*Costo ELSE 0 END) FROM dbo.Inv_Inventario WHERE IdInventario=@Id),
             SALIDAS=(SELECT SUM(CASE WHEN CF<Stock THEN (CF-Stock)*Costo ELSE 0 END) FROM dbo.Inv_Inventario WHERE IdInventario=@Id),
             DIFERENCIAS=(SELECT SUM((CF-Stock)*Costo) FROM dbo.Inv_Inventario WHERE IdInventario=@Id)
             WHERE id=@Id AND ISNULL(Cerrado,0)=0;
         IF @@ROWCOUNT<>1 BEGIN SELECT 0; RETURN; END;
         SELECT 1;
         """;
        await using var command = new SqlCommand(sql, c, tx) { CommandTimeout = timeout };
        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
        var succeeded = Convert.ToInt32(await command.ExecuteScalarAsync(t)) == 1;
        if (succeeded) await tx.CommitAsync(t); else await tx.RollbackAsync(t);
        return succeeded;
    }
    private static PhysicalInventory Map(SqlDataReader r) => new(Convert.ToInt32(r["id"]), DateOnly.FromDateTime(Convert.ToDateTime(r["Fecha"])), S(r, "Titulo"), S(r, "Comentario"), B(r, "Cerrado"), D(r, "InvInicial"), D(r, "InvFinal"), D(r, "ENTRADAS"), D(r, "SALIDAS"), D(r, "DIFERENCIAS")); private static string S(SqlDataReader r, string n) => r[n] is DBNull ? "" : Convert.ToString(r[n])?.Trim() ?? ""; private static decimal D(SqlDataReader r, string n) => r[n] is DBNull ? 0 : Convert.ToDecimal(r[n]); private static bool B(SqlDataReader r, string n) => r[n] is not DBNull && (r[n] is bool b ? b : Convert.ToString(r[n])?.Trim() is "1" or "True" or "TRUE"); private static void P(SqlCommand c, string n, int z, string? v) => c.Parameters.Add(n, SqlDbType.NVarChar, z).Value = v?.Trim() ?? ""; private static void Dec(SqlCommand c, string n, decimal v) { var p = c.Parameters.Add(n, SqlDbType.Decimal); p.Precision = 19; p.Scale = 4; p.Value = v; }
    private async ValueTask<SqlConnection> Open(CancellationToken t) { var c = new SqlConnection(connectionString); await c.OpenAsync(t); return c; }
    private SqlCommand Cmd(string s, SqlConnection c) => new(s, c) { CommandTimeout = timeout };
}
