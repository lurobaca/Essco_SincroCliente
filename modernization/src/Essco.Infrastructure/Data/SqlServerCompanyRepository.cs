using System.Data;
using Essco.Application.Companies;
using Essco.Domain.Companies;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerCompanyRepository(string connectionString, int commandTimeoutSeconds) : ICompanyRepository
{
    public async ValueTask<CompanyProfile?> GetAsync(CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT TOP (2)
                [Cedula], [Tipo_Cedula], [Nombre], [Nombre_Fantacia], [Telefono], [Telefono2],
                [Correo], [Web], [Direccion], [id_Provincia], [id_canton], [id_distrito], [id_barrio],
                [CodigoActividadEconomica], [DescrActividadEconomica], [NumMaxFactura], [DescMax],
                [Conse_RepCarga], [Conse_RepDevoluciones], [DiasExtencion], [TipoGrupoDescuento]
            FROM [dbo].[Empresa];
            """;
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        await using var command = new SqlCommand(sql, connection) { CommandTimeout = commandTimeoutSeconds };
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken)) return null;
        var company = Map(reader);
        if (await reader.ReadAsync(cancellationToken))
            throw new DataException("La tabla Empresa contiene más de un registro; se requiere corrección antes de migrar.");
        return company;
    }

    public async ValueTask SaveAsync(CompanyProfile company, CancellationToken cancellationToken)
    {
        const string sql = """
            IF (SELECT COUNT_BIG(*) FROM [dbo].[Empresa] WITH (UPDLOCK, HOLDLOCK)) > 1
                THROW 51000, 'La tabla Empresa contiene más de un registro.', 1;

            IF EXISTS (SELECT 1 FROM [dbo].[Empresa] WITH (UPDLOCK, HOLDLOCK))
            BEGIN
                UPDATE [dbo].[Empresa] SET
                    [Cedula]=@TaxId, [Tipo_Cedula]=@IdentificationType, [Nombre]=@LegalName,
                    [Nombre_Fantacia]=@TradeName, [Telefono]=@Phone, [Telefono2]=@SecondaryPhone,
                    [Correo]=@Email, [Web]=@Website, [Direccion]=@Address,
                    [id_Provincia]=@ProvinceId, [id_canton]=@CantonId, [id_distrito]=@DistrictId,
                    [id_barrio]=@NeighborhoodId, [CodigoActividadEconomica]=@EconomicActivityCode,
                    [DescrActividadEconomica]=@EconomicActivityDescription, [NumMaxFactura]=@MaximumInvoiceLines,
                    [DescMax]=@MaximumDiscountPercent, [Conse_RepCarga]=@LoadReportSequence,
                    [Conse_RepDevoluciones]=@ReturnReportSequence, [DiasExtencion]=@ExtensionDays,
                    [TipoGrupoDescuento]=@DiscountGrouping;
            END
            ELSE
            BEGIN
                INSERT INTO [dbo].[Empresa]
                    ([Cedula], [Tipo_Cedula], [Nombre], [Nombre_Fantacia], [Telefono], [Telefono2],
                     [Correo], [Web], [Direccion], [id_Provincia], [id_canton], [id_distrito], [id_barrio],
                     [CodigoActividadEconomica], [DescrActividadEconomica], [NumMaxFactura], [DescMax],
                     [Conse_RepCarga], [Conse_RepDevoluciones], [DiasExtencion], [TipoGrupoDescuento])
                VALUES
                    (@TaxId, @IdentificationType, @LegalName, @TradeName, @Phone, @SecondaryPhone,
                     @Email, @Website, @Address, @ProvinceId, @CantonId, @DistrictId, @NeighborhoodId,
                     @EconomicActivityCode, @EconomicActivityDescription, @MaximumInvoiceLines, @MaximumDiscountPercent,
                     @LoadReportSequence, @ReturnReportSequence, @ExtensionDays, @DiscountGrouping);
            END;
            """;

        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, cancellationToken);
        await using var command = new SqlCommand(sql, connection, transaction) { CommandTimeout = commandTimeoutSeconds };
        AddParameters(command, company);
        await command.ExecuteNonQueryAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }

    private static CompanyProfile Map(SqlDataReader reader) => new()
    {
        TaxId = Text(reader, "Cedula"),
        IdentificationType = (CompanyIdentificationType)Integer(reader, "Tipo_Cedula"),
        LegalName = Text(reader, "Nombre"),
        TradeName = Text(reader, "Nombre_Fantacia"),
        Phone = Text(reader, "Telefono"),
        SecondaryPhone = NullableText(reader, "Telefono2"),
        Email = Text(reader, "Correo"),
        Website = NullableText(reader, "Web"),
        Address = Text(reader, "Direccion"),
        ProvinceId = Integer(reader, "id_Provincia"),
        CantonId = Integer(reader, "id_canton"),
        DistrictId = Integer(reader, "id_distrito"),
        NeighborhoodId = Integer(reader, "id_barrio"),
        EconomicActivityCode = NullableText(reader, "CodigoActividadEconomica"),
        EconomicActivityDescription = NullableText(reader, "DescrActividadEconomica"),
        MaximumInvoiceLines = Integer(reader, "NumMaxFactura"),
        MaximumDiscountPercent = Decimal(reader, "DescMax"),
        LoadReportSequence = Integer(reader, "Conse_RepCarga"),
        ReturnReportSequence = Integer(reader, "Conse_RepDevoluciones"),
        ExtensionDays = Integer(reader, "DiasExtencion"),
        DiscountGrouping = (DiscountGroupingType)Integer(reader, "TipoGrupoDescuento")
    };

    private static string Text(SqlDataReader reader, string name) => Convert.ToString(reader[name], System.Globalization.CultureInfo.InvariantCulture)?.Trim() ?? "";
    private static string? NullableText(SqlDataReader reader, string name) => reader[name] is DBNull ? null : Text(reader, name);
    private static int Integer(SqlDataReader reader, string name) => Convert.ToInt32(reader[name] is DBNull ? 0 : reader[name], System.Globalization.CultureInfo.InvariantCulture);
    private static decimal Decimal(SqlDataReader reader, string name) => Convert.ToDecimal(reader[name] is DBNull ? 0m : reader[name], System.Globalization.CultureInfo.InvariantCulture);

    private static void AddParameters(SqlCommand command, CompanyProfile company)
    {
        Add(command, "@TaxId", SqlDbType.NVarChar, company.TaxId, 32);
        Add(command, "@IdentificationType", SqlDbType.Int, (int)company.IdentificationType);
        Add(command, "@LegalName", SqlDbType.NVarChar, company.LegalName.Trim(), 80);
        Add(command, "@TradeName", SqlDbType.NVarChar, company.TradeName.Trim(), 80);
        Add(command, "@Phone", SqlDbType.NVarChar, company.Phone.Trim(), 30);
        Add(command, "@SecondaryPhone", SqlDbType.NVarChar, company.SecondaryPhone, 30);
        Add(command, "@Email", SqlDbType.NVarChar, company.Email.Trim(), 254);
        Add(command, "@Website", SqlDbType.NVarChar, company.Website, 512);
        Add(command, "@Address", SqlDbType.NVarChar, company.Address.Trim(), 500);
        Add(command, "@ProvinceId", SqlDbType.Int, company.ProvinceId);
        Add(command, "@CantonId", SqlDbType.Int, company.CantonId);
        Add(command, "@DistrictId", SqlDbType.Int, company.DistrictId);
        Add(command, "@NeighborhoodId", SqlDbType.Int, company.NeighborhoodId);
        Add(command, "@EconomicActivityCode", SqlDbType.NVarChar, company.EconomicActivityCode, 32);
        Add(command, "@EconomicActivityDescription", SqlDbType.NVarChar, company.EconomicActivityDescription, 256);
        Add(command, "@MaximumInvoiceLines", SqlDbType.Int, company.MaximumInvoiceLines);
        Add(command, "@MaximumDiscountPercent", SqlDbType.Decimal, company.MaximumDiscountPercent, precision: 18, scale: 4);
        Add(command, "@LoadReportSequence", SqlDbType.Int, company.LoadReportSequence);
        Add(command, "@ReturnReportSequence", SqlDbType.Int, company.ReturnReportSequence);
        Add(command, "@ExtensionDays", SqlDbType.Int, company.ExtensionDays);
        Add(command, "@DiscountGrouping", SqlDbType.Int, (int)company.DiscountGrouping);
    }

    private static void Add(SqlCommand command, string name, SqlDbType type, object? value, int? size = null, byte? precision = null, byte? scale = null)
    {
        var parameter = size is null ? command.Parameters.Add(name, type) : command.Parameters.Add(name, type, size.Value);
        if (precision is not null) parameter.Precision = precision.Value;
        if (scale is not null) parameter.Scale = scale.Value;
        parameter.Value = value ?? DBNull.Value;
    }
}
