using Essco.Application.Companies;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerGeographyRepository(string connectionString, int commandTimeoutSeconds) : IGeographyRepository
{
    public ValueTask<IReadOnlyCollection<LocationOption>> GetProvincesAsync(CancellationToken cancellationToken) =>
        QueryAsync("id_provincia", "nombre_provincia", "", [], cancellationToken);

    public ValueTask<IReadOnlyCollection<LocationOption>> GetCantonsAsync(int provinceId, CancellationToken cancellationToken) =>
        QueryAsync("id_canton", "nombre_canton", "WHERE id_provincia=@ProvinceId",
            [new("@ProvinceId", provinceId)], cancellationToken);

    public ValueTask<IReadOnlyCollection<LocationOption>> GetDistrictsAsync(int provinceId, int cantonId, CancellationToken cancellationToken) =>
        QueryAsync("id_distrito", "nombre_distrito", "WHERE id_provincia=@ProvinceId AND id_canton=@CantonId",
            [new("@ProvinceId", provinceId), new("@CantonId", cantonId)], cancellationToken);

    public ValueTask<IReadOnlyCollection<LocationOption>> GetNeighborhoodsAsync(int provinceId, int cantonId, int districtId, CancellationToken cancellationToken) =>
        QueryAsync("id_barrio", "nombre_barrio", "WHERE id_provincia=@ProvinceId AND id_canton=@CantonId AND id_distrito=@DistrictId",
            [new("@ProvinceId", provinceId), new("@CantonId", cantonId), new("@DistrictId", districtId)], cancellationToken);

    private async ValueTask<IReadOnlyCollection<LocationOption>> QueryAsync(
        string idColumn, string nameColumn, string where, IReadOnlyCollection<SqlParameter> parameters,
        CancellationToken cancellationToken)
    {
        var sql = $"SELECT [{idColumn}], [{nameColumn}] FROM [dbo].[Ubicaciones_CostaRica] {where} GROUP BY [{idColumn}], [{nameColumn}] ORDER BY [{idColumn}]";
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        await using var command = new SqlCommand(sql, connection) { CommandTimeout = commandTimeoutSeconds };
        foreach (var parameter in parameters) command.Parameters.Add(parameter);
        var result = new List<LocationOption>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
            result.Add(new(Convert.ToInt32(reader[0]), Convert.ToString(reader[1])?.Trim() ?? ""));
        return result;
    }
}
