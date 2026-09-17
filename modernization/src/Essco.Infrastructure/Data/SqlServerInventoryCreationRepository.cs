using System.Data;
using System.Globalization;
using Essco.Application.Inventory;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;

public sealed class SqlServerInventoryCreationRepository(string connectionString, int timeout) : IInventoryCreationRepository
{
    public async ValueTask<InventoryCreationResult> CreateAsync(string title, string comments, CancellationToken token)
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        await using (var check = Cmd("SELECT COUNT(*) FROM dbo.Inv_Registro WITH (UPDLOCK,HOLDLOCK) WHERE ISNULL(Cerrado,0)=0", connection, transaction))
        {
            if (Convert.ToInt32(await check.ExecuteScalarAsync(token)) > 0)
                return new(false, Error: "Existe un inventario abierto.");
        }

        // Validate legacy integer destinations before inserting the header. The source
        // view exposes Sector as text and stock/pack as numeric, unlike the destination.
        await using (var check = Cmd("SELECT Sector,Stock_B1,Empaque FROM dbo.Inve_Conteo WITH (HOLDLOCK)", connection, transaction))
        await using (var reader = await check.ExecuteReaderAsync(token))
        {
            var hasRows = false;
            while (await reader.ReadAsync(token))
            {
                hasRows = true;
                var sector = Convert.ToString(reader["Sector"], CultureInfo.InvariantCulture)?.Trim();
                if (!string.IsNullOrEmpty(sector) && !int.TryParse(sector, NumberStyles.Integer, CultureInfo.InvariantCulture, out _))
                    return new(false, Error: "El universo contiene un sector que no es un entero válido. Corrija el origen antes de crear el inventario.");
                foreach (var column in new[] { "Stock_B1", "Empaque" })
                {
                    var value = reader[column] is DBNull ? 0m : Convert.ToDecimal(reader[column], CultureInfo.InvariantCulture);
                    if (value != decimal.Truncate(value) || value < int.MinValue || value > int.MaxValue)
                        return new(false, Error: "El stock o empaque no cabe en las columnas enteras del inventario heredado. No se creó el inventario.");
                }
            }
            if (!hasRows) return new(false, Error: "El universo Inve_Conteo está vacío.");
        }

        int id;
        await using (var head = Cmd("""
            INSERT INTO dbo.Inv_Registro(Fecha,Titulo,Comentario,Cerrado,InvInicial,InvFinal,ENTRADAS,SALIDAS,DIFERENCIAS)
            OUTPUT INSERTED.id VALUES(CAST(SYSDATETIME() AS date),@Title,@Comments,0,0,0,0,0,0)
            """, connection, transaction))
        {
            P(head, "@Title", 300, title);
            P(head, "@Comments", 1000, comments);
            id = Convert.ToInt32(await head.ExecuteScalarAsync(token));
        }
        const string copy = """
            INSERT INTO dbo.Inv_Inventario
                (Fecha,IdInventario,Codigo,Descripcion,CodBarras,Sector,Costo,CodProveedor,NameProveedor,Stock,Monto,Reconteo,CF,DF,DFM,Pack,NumLinea)
            SELECT CAST(SYSDATETIME() AS date),@Id,ItemCode,ItemName,ISNULL(CodeBars,''),
                ISNULL(CONVERT(int,NULLIF(LTRIM(RTRIM(Sector)),'')),0),
                ISNULL(CONVERT(decimal(19,4),Price),0),ISNULL(CodProveedor,''),ISNULL(NameProveedor,''),
                ISNULL(CONVERT(int,Stock_B1),0),ISNULL(CONVERT(decimal(19,4),Monto_B1),0),0,0,
                -ISNULL(CONVERT(decimal(19,4),Stock_B1),0),-ISNULL(CONVERT(decimal(19,4),Monto_B1),0),
                ISNULL(CONVERT(int,Empaque),0),ROW_NUMBER() OVER(ORDER BY ItemCode)-1
            FROM dbo.Inve_Conteo
            """;
        await using (var insert = Cmd(copy, connection, transaction))
        {
            insert.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            await insert.ExecuteNonQueryAsync(token);
        }
        await using (var total = Cmd("""
            UPDATE R SET InvInicial=X.Total FROM dbo.Inv_Registro R
            CROSS APPLY(SELECT ISNULL(SUM(Monto),0) Total FROM dbo.Inv_Inventario WHERE IdInventario=@Id) X WHERE R.id=@Id
            """, connection, transaction))
        {
            total.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            await total.ExecuteNonQueryAsync(token);
        }
        await transaction.CommitAsync(token);
        return new(true, id);
    }

    private SqlCommand Cmd(string sql, SqlConnection connection, SqlTransaction transaction) =>
        new(sql, connection, transaction) { CommandTimeout = timeout };
    private static void P(SqlCommand command, string name, int size, string value) =>
        command.Parameters.Add(name, SqlDbType.NVarChar, size).Value = value;
}
