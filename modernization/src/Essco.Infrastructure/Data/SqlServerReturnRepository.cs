using System.Data;
using Essco.Application.Returns;
using Essco.Domain.Returns;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;

public sealed class SqlServerReturnRepository(string connectionString, int timeout) : IReturnRepository
{
    public async ValueTask<IReadOnlyCollection<ReturnRequest>> ListAsync(ReturnFilter f, CancellationToken t) { await using var c = await Open(t); await using var cmd = Command("", c); var w = new List<string>(); if (f.Processed is not null) { w.Add("[Procesada]=@Processed"); cmd.Parameters.Add("@Processed", SqlDbType.Bit).Value = f.Processed; } if (!string.IsNullOrWhiteSpace(f.DriverCode)) { w.Add("[CodChofer]=@Driver"); cmd.Parameters.Add("@Driver", SqlDbType.NVarChar, 50).Value = f.DriverCode.Trim(); } if (f.Number is not null) { w.Add("[DocNum]=@Number"); cmd.Parameters.Add("@Number", SqlDbType.Int).Value = f.Number; } cmd.CommandText = $"SELECT TOP(500) [DocNum],MIN([FechaNota]) [FechaNota],MAX([CodChofer]) [CodChofer],MAX([NombreChofer]) [NombreChofer],MAX([CodCliente]) [CodCliente],MAX([NombreCliente]) [NombreCliente],MAX([Credito]) [Credito],SUM([Total]) [Total],MAX([NumFactura]) [NumFactura],MAX([Motivo]) [Motivo],MAX([Procesada]) [Procesada],MAX([DocEntry]) [DocEntry],MAX([Ruta]) [Ruta],MAX([NumMarchamo]) [NumMarchamo],MAX([Comentario]) [Comentario] FROM [dbo].[Devoluciones]{(w.Count == 0 ? "" : " WHERE " + string.Join(" AND ", w))} GROUP BY [DocNum] ORDER BY [DocNum] DESC"; var list = new List<ReturnRequest>(); await using var r = await cmd.ExecuteReaderAsync(t); while (await r.ReadAsync(t)) list.Add(Header(r, [])); return list; }
    public async ValueTask<ReturnRequest?> GetAsync(int n, CancellationToken t) { await using var c = await Open(t); ReturnRequest? h; await using (var cmd = Command("SELECT TOP(1) [DocNum],[FechaNota],[CodChofer],[NombreChofer],[CodCliente],[NombreCliente],[Credito],[Total],[NumFactura],[Motivo],[Procesada],[DocEntry],[Ruta],[NumMarchamo],[Comentario] FROM [dbo].[Devoluciones] WHERE [DocNum]=@Number", c)) { cmd.Parameters.Add("@Number", SqlDbType.Int).Value = n; await using var r = await cmd.ExecuteReaderAsync(t); h = await r.ReadAsync(t) ? Header(r, []) : null; } if (h is null) return null; var lines = new List<ReturnLine>(); var hasWarehouse = await HasReasonWarehouseAsync(c, t); var detail = hasWarehouse ? "SELECT D.[NumLinea],D.[ItemCode],D.[ItemName],D.[Precio],D.[Quantity],D.[Porc_Desc_Fijo],D.[Porc_Desc_Promo],D.[Porc_Imp],D.[Total],D.[Motivo],D.[Comentarios],ISNULL(M.[Bodega],'') [Bodega] FROM [dbo].[DevolucionesDetalle] D LEFT JOIN [dbo].[MotivoDevolucion] M ON M.[Descripcion]=D.[Motivo] WHERE D.[DocNum]=@Number ORDER BY D.[NumLinea]" : "SELECT D.[NumLinea],D.[ItemCode],D.[ItemName],D.[Precio],D.[Quantity],D.[Porc_Desc_Fijo],D.[Porc_Desc_Promo],D.[Porc_Imp],D.[Total],D.[Motivo],D.[Comentarios],CAST('' AS varchar(20)) [Bodega] FROM [dbo].[DevolucionesDetalle] D WHERE D.[DocNum]=@Number ORDER BY D.[NumLinea]"; await using (var cmd = Command(detail, c)) { cmd.Parameters.Add("@Number", SqlDbType.Int).Value = n; await using var r = await cmd.ExecuteReaderAsync(t); while (await r.ReadAsync(t)) lines.Add(new(Convert.ToInt32(r["NumLinea"]), S(r, "ItemCode"), S(r, "ItemName"), D(r, "Precio"), D(r, "Quantity"), D(r, "Porc_Desc_Fijo"), D(r, "Porc_Desc_Promo"), D(r, "Porc_Imp"), D(r, "Total"), S(r, "Motivo"), S(r, "Comentarios"), S(r, "Bodega"))); } return h with { Lines = lines }; }
    public async ValueTask<bool> SaveLineAsync(ReturnLineDraft line, CancellationToken token)
    {
        await using var connection = await Open(token);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        const string sql = """
   SET NOCOUNT ON;
   IF (SELECT COUNT(*) FROM dbo.Devoluciones WITH(UPDLOCK,HOLDLOCK)
       WHERE DocNum=@Number AND ISNULL(Procesada,0)=0)<>1
       BEGIN SELECT 0; RETURN; END;
   DECLARE @Price float,@Tax int;
   SELECT @Price=Precio,@Tax=ISNULL(Porc_Imp,0)
   FROM dbo.DevolucionesDetalle WITH(UPDLOCK,HOLDLOCK)
   WHERE DocNum=@Number AND NumLinea=@Line;
   IF @@ROWCOUNT<>1 OR @Price IS NULL OR @Price<0 OR @Tax<0 OR @Tax>100
       BEGIN SELECT 0; RETURN; END;
   DECLARE @Discount float=@Fixed+@Promo;
   DECLARE @Gross float=@Quantity*@Price;
   DECLARE @DiscountAmount float=CASE WHEN @Discount=100 THEN 0 ELSE @Gross*@Discount/100 END;
   DECLARE @Subtotal float=@Gross-@DiscountAmount;
   DECLARE @TaxAmount float=@Subtotal*@Tax/100;
   DECLARE @Total float=CASE WHEN @Discount=100 THEN @TaxAmount ELSE @Subtotal+@TaxAmount END;
   UPDATE dbo.DevolucionesDetalle SET Quantity=@Quantity,Porc_Desc=@Discount,
       Porc_Desc_Fijo=@Fixed,Porc_Desc_Promo=@Promo,Motivo=@Reason,Comentarios=@Comments,
       Mont_Imp=@TaxAmount,Sub_Total=@Subtotal,Mont_Desc=@DiscountAmount,Total=@Total
   WHERE DocNum=@Number AND NumLinea=@Line AND ISNULL(Procesada,0)=0;
   IF @@ROWCOUNT<>1 BEGIN SELECT 0; RETURN; END;
   UPDATE H SET Mont_Imp=X.Tax,Sub_Total=X.Subtotal,Mont_Desc=X.Discount,Total=X.Total
   FROM dbo.Devoluciones H
   CROSS APPLY(SELECT ISNULL(SUM(ISNULL(Mont_Imp,0)),0) Tax,
      ISNULL(SUM(ISNULL(Sub_Total,0)),0) Subtotal,
      ISNULL(SUM(ISNULL(Mont_Desc,0)),0) Discount,
      ISNULL(SUM(ISNULL(Total,0)),0) Total
      FROM dbo.DevolucionesDetalle WHERE DocNum=@Number) X
   WHERE H.DocNum=@Number AND ISNULL(H.Procesada,0)=0;
   IF @@ROWCOUNT<>1 BEGIN SELECT 0; RETURN; END;
   SELECT 1;
   """;
        await using var command = Command(sql, connection, transaction);
        command.Parameters.Add("@Number", SqlDbType.Int).Value = line.ReturnNumber;
        command.Parameters.Add("@Line", SqlDbType.Int).Value = line.LineNumber;
        command.Parameters.Add("@Quantity", SqlDbType.Int).Value = decimal.ToInt32(line.Quantity);
        AddDecimal(command, "@Fixed", line.FixedDiscount);
        AddDecimal(command, "@Promo", line.PromotionalDiscount);
        command.Parameters.Add("@Reason", SqlDbType.VarChar, 200).Value = line.Reason.Trim();
        command.Parameters.Add("@Comments", SqlDbType.VarChar, 200).Value = line.Comments?.Trim() ?? "";
        var succeeded = Convert.ToInt32(await command.ExecuteScalarAsync(token)) == 1;
        if (succeeded) await transaction.CommitAsync(token); else await transaction.RollbackAsync(token);
        return succeeded;
    }
    private static void AddDecimal(SqlCommand command, string name, decimal value)
    { var parameter = command.Parameters.Add(name, SqlDbType.Decimal); parameter.Precision = 9; parameter.Scale = 4; parameter.Value = value; }
    public async ValueTask<bool> AddLineAsync(NewReturnLine line, CancellationToken token)
    {
        await using var c = await Open(token); await using var tx = (SqlTransaction)await c.BeginTransactionAsync(IsolationLevel.Serializable, token);
        const string sql = """
   SET NOCOUNT ON;
   IF NOT EXISTS(SELECT 1 FROM dbo.Devoluciones WITH(UPDLOCK,HOLDLOCK) WHERE DocNum=@Number AND ISNULL(Procesada,0)=0)
      OR EXISTS(SELECT 1 FROM dbo.DevolucionesDetalle WITH(UPDLOCK,HOLDLOCK) WHERE DocNum=@Number AND ItemCode=@Code)
      BEGIN SELECT 0; RETURN; END;
   DECLARE @Line int=ISNULL((SELECT MAX(NumLinea) FROM dbo.DevolucionesDetalle WITH(UPDLOCK,HOLDLOCK) WHERE DocNum=@Number),-1)+1;
   INSERT dbo.DevolucionesDetalle(DocNum,ItemCode,ItemName,Precio,Quantity,Porc_Desc,Motivo,Porc_Desc_Fijo,Porc_Desc_Promo,Porc_Imp,Mont_Imp,Sub_Total,Mont_Desc,Total,Procesada,Comentarios,NumLinea)
   VALUES(@Number,@Code,@Name,@Price,0,0,'',0,0,@Tax,0,0,0,0,0,'',@Line);
   SELECT CASE WHEN @@ROWCOUNT=1 THEN 1 ELSE 0 END;
   """;
        await using var cmd = Command(sql, c, tx); cmd.Parameters.Add("@Number", SqlDbType.Int).Value = line.ReturnNumber; cmd.Parameters.Add("@Code", SqlDbType.VarChar, 10).Value = line.ItemCode.Trim(); cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = line.ItemName.Trim(); AddDecimal(cmd, "@Price", line.Price); AddDecimal(cmd, "@Tax", line.TaxPercent);
        var ok = Convert.ToInt32(await cmd.ExecuteScalarAsync(token)) == 1; if (ok) await tx.CommitAsync(token); else await tx.RollbackAsync(token); return ok;
    }
    public async ValueTask<bool> DeleteLineAsync(int number, int lineNumber, CancellationToken token)
    {
        await using var c = await Open(token); await using var tx = (SqlTransaction)await c.BeginTransactionAsync(IsolationLevel.Serializable, token);
        const string sql = """
   SET NOCOUNT ON;
   IF NOT EXISTS(SELECT 1 FROM dbo.Devoluciones WITH(UPDLOCK,HOLDLOCK) WHERE DocNum=@Number AND ISNULL(Procesada,0)=0)
      BEGIN SELECT 0; RETURN; END;
   DELETE dbo.DevolucionesDetalle WHERE DocNum=@Number AND NumLinea=@Line AND ISNULL(Procesada,0)=0;
   IF @@ROWCOUNT<>1 BEGIN SELECT 0; RETURN; END;
   UPDATE H SET Mont_Imp=X.Tax,Sub_Total=X.Subtotal,Mont_Desc=X.Discount,Total=X.Total
   FROM dbo.Devoluciones H CROSS APPLY(SELECT ISNULL(SUM(ISNULL(Mont_Imp,0)),0) Tax,ISNULL(SUM(ISNULL(Sub_Total,0)),0) Subtotal,ISNULL(SUM(ISNULL(Mont_Desc,0)),0) Discount,ISNULL(SUM(ISNULL(Total,0)),0) Total FROM dbo.DevolucionesDetalle WHERE DocNum=@Number) X
   WHERE H.DocNum=@Number AND ISNULL(H.Procesada,0)=0;
   SELECT CASE WHEN @@ROWCOUNT>0 THEN 1 ELSE 0 END;
   """;
        await using var cmd = Command(sql, c, tx); cmd.Parameters.Add("@Number", SqlDbType.Int).Value = number; cmd.Parameters.Add("@Line", SqlDbType.Int).Value = lineNumber; var ok = Convert.ToInt32(await cmd.ExecuteScalarAsync(token)) == 1; if (ok) await tx.CommitAsync(token); else await tx.RollbackAsync(token); return ok;
    }
    public async ValueTask<bool> MarkProcessedAsync(int n, int entry, CancellationToken t) { await using var c = await Open(t); await using var tx = (SqlTransaction)await c.BeginTransactionAsync(t); try { await using var a = Command("UPDATE [dbo].[Devoluciones] SET [Procesada]=1,[DocEntry]=@Entry WHERE [DocNum]=@Number AND ISNULL([Procesada],0)<>1", c, tx); a.Parameters.Add("@Entry", SqlDbType.Int).Value = entry; a.Parameters.Add("@Number", SqlDbType.Int).Value = n; var changed = await a.ExecuteNonQueryAsync(t); await using var b = Command("UPDATE [dbo].[DevolucionesDetalle] SET [Procesada]=1 WHERE [DocNum]=@Number", c, tx); b.Parameters.Add("@Number", SqlDbType.Int).Value = n; await b.ExecuteNonQueryAsync(t); await tx.CommitAsync(t); return changed > 0; } catch { await tx.RollbackAsync(t); throw; } }
    private static ReturnRequest Header(SqlDataReader r, IReadOnlyCollection<ReturnLine> lines) => new(Convert.ToInt32(r["DocNum"]), DateOnly.FromDateTime(Convert.ToDateTime(r["FechaNota"])), S(r, "CodChofer"), S(r, "NombreChofer"), S(r, "CodCliente"), S(r, "NombreCliente"), B(r, "Credito"), D(r, "Total"), S(r, "NumFactura"), S(r, "Motivo"), B(r, "Procesada"), r["DocEntry"] is DBNull ? null : Convert.ToInt32(r["DocEntry"]), S(r, "Ruta"), S(r, "NumMarchamo"), S(r, "Comentario"), lines); private static string S(SqlDataReader r, string n) => Convert.ToString(r[n])?.Trim() ?? ""; private static decimal D(SqlDataReader r, string n) => r[n] is DBNull ? 0 : Convert.ToDecimal(r[n]); private static bool B(SqlDataReader r, string n) { if (r[n] is DBNull) return false; if (r[n] is bool b) return b; var s = Convert.ToString(r[n])?.Trim(); return s is "1" or "SI" or "Sí" or "TRUE" or "True" or "Y"; }
    private async ValueTask<SqlConnection> Open(CancellationToken t) { var c = new SqlConnection(connectionString); await c.OpenAsync(t); return c; }
    private SqlCommand Command(string s, SqlConnection c, SqlTransaction? t = null) => new(s, c, t) { CommandTimeout = timeout };
    private async ValueTask<bool> HasReasonWarehouseAsync(SqlConnection c, CancellationToken t) { await using var cmd = Command("SELECT CASE WHEN COL_LENGTH('dbo.MotivoDevolucion','Bodega') IS NULL THEN 0 ELSE 1 END", c); return Convert.ToInt32(await cmd.ExecuteScalarAsync(t)) == 1; }
}
