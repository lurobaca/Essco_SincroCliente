using System.Data;
using Essco.Application.Inventory;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;

public sealed class SqlServerInventoryConsolidationReadiness(string connectionString, int timeout)
    : IInventoryConsolidationReadiness
{
    public async ValueTask<IReadOnlyCollection<InventoryGroupCompletion>> GetAsync(int inventory, string supplier, CancellationToken token)
    {
        if (inventory <= 0 || string.IsNullOrWhiteSpace(supplier)) return [];
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(token);
        const string sql = """
            SELECT G.idGrupo, COUNT(A.Conteo) Controls,
                SUM(CASE WHEN A.Finalizado=1 THEN 1 ELSE 0 END) Completed
            FROM (SELECT DISTINCT idGrupo FROM dbo.Inv_Grupos
                  WHERE CodInventario=@Id AND CodProveedor=@Supplier AND LEN(idGrupo)=1) G
            LEFT JOIN dbo.Inv_ConActivo A ON A.IdInventario=@Id AND A.Grupo=G.idGrupo AND A.Conteo>=3
                AND A.Conteo=(SELECT MAX(N.Conteo) FROM dbo.Inv_ConActivo N WHERE N.IdInventario=@Id AND N.Grupo=G.idGrupo)
            GROUP BY G.idGrupo ORDER BY G.idGrupo
            """;
        await using var command = new SqlCommand(sql, connection) { CommandTimeout = timeout };
        command.Parameters.Add("@Id", SqlDbType.Int).Value = inventory;
        command.Parameters.Add("@Supplier", SqlDbType.NVarChar, 100).Value = supplier.Trim();
        var result = new List<InventoryGroupCompletion>();
        await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token))
            result.Add(new(Convert.ToString(reader[0])?.Trim() ?? "", Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
        return result;
    }
}
public sealed class UnavailableInventoryConsolidationReadiness : IInventoryConsolidationReadiness
{
    public ValueTask<IReadOnlyCollection<InventoryGroupCompletion>> GetAsync(int inventory, string supplier, CancellationToken token)
        => ValueTask.FromResult<IReadOnlyCollection<InventoryGroupCompletion>>([]);
}
