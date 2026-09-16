using System.Data;
using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerWarehouseRepository(string connectionString, int timeout) : IWarehouseRepository
{
    public async ValueTask<IReadOnlyCollection<PickingWarehouse>> ListAsync(CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var command = Command("SELECT [id],[Nombre],[Ubicacion],[Racks],[Columnas],[Predeterminado] FROM [dbo].[Picking_Bodega] ORDER BY [id]", connection);
        var result = new List<PickingWarehouse>();
        await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token)) result.Add(Read(reader));
        return result;
    }

    public async ValueTask<int> NextIdAsync(CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var command = Command("SELECT ISNULL(MAX([IdBodega]),0)+1 FROM [dbo].[Picking_Bodega]", connection);
        return Convert.ToInt32(await command.ExecuteScalarAsync(token));
    }

    public async ValueTask<WarehouseWriteResult> SaveAsync(PickingWarehouse warehouse, bool isNew, CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        try
        {
            PickingWarehouse? previous = null;
            if (!isNew)
            {
                previous = await FindAsync(warehouse.Id, connection, transaction, token);
                if (previous is null) return await RollbackAsync(transaction, "La bodega ya no existe.", token);
                if ((warehouse.Racks < previous.Racks || warehouse.Columns < previous.Columns) &&
                    await HasProtectedLocationsAsync(previous, warehouse.Racks, warehouse.Columns, connection, transaction, token))
                    return await RollbackAsync(transaction, "No se puede reducir la geometría porque existen ubicaciones en el área que se eliminaría.", token);
            }

            if (warehouse.IsDefault)
            {
                await using var clear = Command("UPDATE [dbo].[Picking_Bodega] SET [Predeterminado]=0 WHERE [Predeterminado]<>0", connection, transaction);
                await clear.ExecuteNonQueryAsync(token);
            }

            var sql = isNew
                ? "INSERT INTO [dbo].[Picking_Bodega]([IdBodega],[Nombre],[Ubicacion],[Racks],[Columnas],[Predeterminado]) VALUES(@Id,@Name,@Location,@Racks,@Columns,@Default)"
                : "UPDATE [dbo].[Picking_Bodega] SET [Nombre]=@Name,[Ubicacion]=@Location,[Racks]=@Racks,[Columnas]=@Columns,[Predeterminado]=@Default WHERE [IdBodega]=@Id";
            await using var command = Command(sql, connection, transaction);
            AddParameters(command, warehouse);
            var changed = await command.ExecuteNonQueryAsync(token);
            if (changed != 1) return await RollbackAsync(transaction, isNew ? "Ya existe una bodega con ese código." : "La bodega ya no existe.", token);
            await transaction.CommitAsync(token);
            return new WarehouseWriteResult(true);
        }
        catch
        {
            await transaction.RollbackAsync(token);
            throw;
        }
    }

    public async ValueTask<WarehouseWriteResult> DeleteAsync(int id, CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        try
        {
            var warehouse = await FindAsync(id, connection, transaction, token);
            if (warehouse is null) return await RollbackAsync(transaction, "La bodega ya no existe.", token);
            if (await HasProtectedLocationsAsync(warehouse, 0, 0, connection, transaction, token))
                return await RollbackAsync(transaction, "No se puede eliminar la bodega porque contiene ubicaciones configuradas.", token);
            await using var command = Command("DELETE FROM [dbo].[Picking_Bodega] WHERE [IdBodega]=@Id", connection, transaction);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            var changed = await command.ExecuteNonQueryAsync(token);
            await transaction.CommitAsync(token);
            return new WarehouseWriteResult(changed == 1, changed == 1 ? null : "La bodega ya no existe.");
        }
        catch
        {
            await transaction.RollbackAsync(token);
            throw;
        }
    }

    private async ValueTask<PickingWarehouse?> FindAsync(int id, SqlConnection connection, SqlTransaction transaction, CancellationToken token)
    {
        await using var command = Command("SELECT [id],[Nombre],[Ubicacion],[Racks],[Columnas],[Predeterminado] FROM [dbo].[Picking_Bodega] WITH (UPDLOCK,HOLDLOCK) WHERE [IdBodega]=@Id", connection, transaction);
        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
        await using var reader = await command.ExecuteReaderAsync(token);
        return await reader.ReadAsync(token) ? Read(reader) : null;
    }

    private async ValueTask<bool> HasProtectedLocationsAsync(PickingWarehouse previous, int newRacks, int newColumns, SqlConnection connection, SqlTransaction transaction, CancellationToken token)
    {
        await using var command = Command("SELECT [Nombre] FROM [dbo].[Picking_Ubicaciones] WITH (HOLDLOCK)", connection, transaction);
        var existing = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        await using (var reader = await command.ExecuteReaderAsync(token))
            while (await reader.ReadAsync(token)) existing.Add(Convert.ToString(reader["Nombre"])?.Trim() ?? "");

        for (var rack = 0; rack < previous.Racks; rack++)
            for (var column = 0; column < previous.Columns; column++)
                if ((rack >= newRacks || column >= newColumns) && existing.Contains($"B{column}-{rack}{previous.Id}")) return true;
        return false;
    }

    private static PickingWarehouse Read(SqlDataReader reader) => new()
    {
        Id = Convert.ToInt32(reader["id"]),
        Name = Convert.ToString(reader["Nombre"])?.Trim() ?? "",
        Location = Convert.ToString(reader["Ubicacion"])?.Trim() ?? "",
        Racks = Convert.ToInt32(reader["Racks"]),
        Columns = Convert.ToInt32(reader["Columnas"]),
        IsDefault = Convert.ToInt32(reader["Predeterminado"]) != 0
    };

    private static void AddParameters(SqlCommand command, PickingWarehouse warehouse)
    {
        command.Parameters.Add("@Id", SqlDbType.Int).Value = warehouse.Id;
        command.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = warehouse.Name.Trim();
        command.Parameters.Add("@Location", SqlDbType.NVarChar, 250).Value = warehouse.Location.Trim();
        command.Parameters.Add("@Racks", SqlDbType.Int).Value = warehouse.Racks;
        command.Parameters.Add("@Columns", SqlDbType.Int).Value = warehouse.Columns;
        command.Parameters.Add("@Default", SqlDbType.Bit).Value = warehouse.IsDefault;
    }

    private static async ValueTask<WarehouseWriteResult> RollbackAsync(SqlTransaction transaction, string error, CancellationToken token)
    {
        await transaction.RollbackAsync(token);
        return new WarehouseWriteResult(false, error);
    }

    private async ValueTask<SqlConnection> OpenAsync(CancellationToken token)
    {
        var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        return connection;
    }

    private SqlCommand Command(string sql, SqlConnection connection, SqlTransaction? transaction = null) => new(sql, connection, transaction) { CommandTimeout = timeout };
}
