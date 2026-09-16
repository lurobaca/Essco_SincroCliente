using System.Data;
using System.Globalization;
using System.Text;
using Essco.Application.Customers;
using Essco.Domain.Customers;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerCustomerChangeRepository(string connectionString, int commandTimeoutSeconds) : ICustomerChangeRepository
{
    private const string Columns = """
        [Consecutivo],[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],
        [Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],
        [Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],
        [Aprobado],[id],[TipoSocio],[EXO_TipoDocumento],[EXO_Numero],[EXO_NombreInstitucion],
        [EXO_FechaEmision],[EXO_PorcentajeCompra],[EXO_FechaVencimiento]
        """;

    public async ValueTask<CustomerSearchResult> SearchAsync(CustomerSearch search, CancellationToken cancellationToken)
    {
        var page = Math.Max(1, search.Page);
        var pageSize = Math.Clamp(search.PageSize, 1, 200);
        var where = new StringBuilder(" WHERE [Aprobado]=@Approved AND [Estado]=@State");
        var parameters = new List<SqlParameter>
        {
            new("@Approved", SqlDbType.Bit) { Value = search.Approved },
            new("@State", SqlDbType.NVarChar, 20) { Value = ToLegacyState(search.State) }
        };
        if (!string.IsNullOrWhiteSpace(search.Term))
        {
            where.Append(search.SearchByName ? " AND [CardName] LIKE @Term" : " AND [CardCode] LIKE @Term");
            parameters.Add(new("@Term", SqlDbType.NVarChar, 202) { Value = $"%{search.Term.Trim()}%" });
        }
        if (!string.IsNullOrWhiteSpace(search.AgentCode))
        {
            where.Append(" AND [Agente]=@Agent");
            parameters.Add(new("@Agent", SqlDbType.NVarChar, 50) { Value = search.AgentCode.Trim() });
        }
        if (search.From is not null && search.To is not null)
        {
            where.Append(" AND [Fecha]>=@From AND [Fecha]<DATEADD(day,1,@To)");
            parameters.Add(new("@From", SqlDbType.Date) { Value = search.From.Value.ToDateTime(TimeOnly.MinValue) });
            parameters.Add(new("@To", SqlDbType.Date) { Value = search.To.Value.ToDateTime(TimeOnly.MinValue) });
        }
        var sql = $"SELECT COUNT_BIG(*) FROM [dbo].[ClientesModificados]{where}; SELECT {Columns} FROM [dbo].[ClientesModificados]{where} ORDER BY [id] DESC OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";
        await using var connection = await OpenAsync(cancellationToken);
        await using var command = new SqlCommand(sql, connection) { CommandTimeout = commandTimeoutSeconds };
        foreach (var parameter in parameters) command.Parameters.Add(parameter);
        command.Parameters.Add("@Offset", SqlDbType.Int).Value = (page - 1) * pageSize;
        command.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        await reader.ReadAsync(cancellationToken);
        var total = checked((int)reader.GetInt64(0));
        await reader.NextResultAsync(cancellationToken);
        var items = new List<CustomerChangeRequest>();
        while (await reader.ReadAsync(cancellationToken)) items.Add(Map(reader));
        return new(items, total);
    }

    public async ValueTask<CustomerChangeRequest?> GetAsync(long id, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);
        await using var command = new SqlCommand($"SELECT {Columns} FROM [dbo].[ClientesModificados] WHERE [id]=@Id", connection) { CommandTimeout = commandTimeoutSeconds };
        command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        return await reader.ReadAsync(cancellationToken) ? Map(reader) : null;
    }

    public async ValueTask<long> SaveAsync(CustomerChangeRequest request, CancellationToken cancellationToken)
    {
        const string insert = """
            IF EXISTS (SELECT 1 FROM [dbo].[ClientesModificados] WITH (UPDLOCK,HOLDLOCK) WHERE [CardCode]=@Code)
                THROW 51002, 'Ya existe una solicitud para el código de cliente indicado.', 1;
            INSERT INTO [dbo].[ClientesModificados]
            ([Consecutivo],[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[TipoSocio],[EXO_TipoDocumento],[EXO_Numero],[EXO_NombreInstitucion],[EXO_FechaEmision],[EXO_PorcentajeCompra],[EXO_FechaVencimiento])
            OUTPUT INSERTED.[id] VALUES
            (@Sequence,@Code,@Name,@TaxId,@TaxResponsible,@VisitSchedule,@WebPassword,@Phone1,@Phone2,@Address,@Email,@TradeName,@Latitude,@Longitude,@Agent,@Province,@Canton,@District,@Neighborhood,@State,@IdentificationType,@Date,@Time,@Approved,@PartnerType,@ExemptionType,@ExemptionNumber,@ExemptionInstitution,@ExemptionIssued,@ExemptionPercent,@ExemptionExpires);
            """;
        const string update = """
            UPDATE [dbo].[ClientesModificados] SET [Consecutivo]=@Sequence,[CardCode]=@Code,[CardName]=@Name,[Cedula]=@TaxId,[Respolsabletributario]=@TaxResponsible,[U_Visita]=@VisitSchedule,[U_ClaveWeb]=@WebPassword,[Phone1]=@Phone1,[Phone2]=@Phone2,[Street]=@Address,[E_Mail]=@Email,[NameFicticio]=@TradeName,[Latitud]=@Latitude,[Longitud]=@Longitude,[Agente]=@Agent,[Id_Provincia]=@Province,[Id_Canton]=@Canton,[Id_Distrito]=@District,[Id_Barrio]=@Neighborhood,[Estado]=@State,[Tipo_Cedula]=@IdentificationType,[Fecha]=@Date,[Hora]=@Time,[Aprobado]=@Approved,[TipoSocio]=@PartnerType,[EXO_TipoDocumento]=@ExemptionType,[EXO_Numero]=@ExemptionNumber,[EXO_NombreInstitucion]=@ExemptionInstitution,[EXO_FechaEmision]=@ExemptionIssued,[EXO_PorcentajeCompra]=@ExemptionPercent,[EXO_FechaVencimiento]=@ExemptionExpires WHERE [id]=@Id;
            SELECT CAST(@Id AS bigint);
            """;
        await using var connection = await OpenAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, cancellationToken);
        var sequence = request.Sequence;
        if (request.Id == 0)
        {
            await using var sequenceCommand = new SqlCommand("""
                IF (SELECT COUNT_BIG(*) FROM [dbo].[Empresa] WITH (UPDLOCK,HOLDLOCK)) <> 1
                    THROW 51001, 'Empresa debe contener exactamente un registro para asignar consecutivo de cliente.', 1;
                UPDATE [dbo].[Empresa] SET [Conse_Clientes]=ISNULL(TRY_CONVERT(int,[Conse_Clientes]),0)+1
                OUTPUT INSERTED.[Conse_Clientes];
                """, connection, transaction) { CommandTimeout = commandTimeoutSeconds };
            sequence = Convert.ToString(await sequenceCommand.ExecuteScalarAsync(cancellationToken), CultureInfo.InvariantCulture) ?? "";
        }
        await using var command = new SqlCommand(request.Id == 0 ? insert : update, connection, transaction) { CommandTimeout = commandTimeoutSeconds };
        AddParameters(command, request);
        command.Parameters["@Sequence"].Value = sequence;
        command.Parameters.Add("@Id", SqlDbType.BigInt).Value = request.Id;
        var id = Convert.ToInt64(await command.ExecuteScalarAsync(cancellationToken), CultureInfo.InvariantCulture);
        await transaction.CommitAsync(cancellationToken);
        return id;
    }

    public async ValueTask<bool> ApproveAsync(long id, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);
        await using var command = new SqlCommand("UPDATE [dbo].[ClientesModificados] SET [Aprobado]=1 WHERE [id]=@Id AND [Aprobado]=0", connection) { CommandTimeout = commandTimeoutSeconds };
        command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
        return await command.ExecuteNonQueryAsync(cancellationToken) == 1;
    }

    private async ValueTask<SqlConnection> OpenAsync(CancellationToken token) { var connection = new SqlConnection(connectionString); await connection.OpenAsync(token); return connection; }
    private static CustomerChangeRequest Map(SqlDataReader r)
    {
        var date = r["Fecha"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(r["Fecha"], CultureInfo.InvariantCulture);
        if (TimeSpan.TryParse(Text(r, "Hora"), CultureInfo.InvariantCulture, out var time)) date = date.Date.Add(time);
        return new() { Id=Value<long>(r,"id"), Sequence=Text(r,"Consecutivo"), Code=Text(r,"CardCode"), Name=Text(r,"CardName"), TaxId=Text(r,"Cedula"), TaxResponsible=NullableText(r,"Respolsabletributario"), VisitSchedule=NullableText(r,"U_Visita"), WebPassword=NullableText(r,"U_ClaveWeb"), Phone1=NullableText(r,"Phone1"), Phone2=NullableText(r,"Phone2"), Address=NullableText(r,"Street"), Email=NullableText(r,"E_Mail"), TradeName=NullableText(r,"NameFicticio"), Latitude=Decimal(r,"Latitud"), Longitude=Decimal(r,"Longitud"), AgentCode=NullableText(r,"Agente"), ProvinceId=Number(r,"Id_Provincia"), CantonId=Number(r,"Id_Canton"), DistrictId=Number(r,"Id_Distrito"), NeighborhoodId=Number(r,"Id_Barrio"), State=ParseState(Text(r,"Estado")), IdentificationType=Number(r,"Tipo_Cedula"), RequestedAt=date, Approved=Boolean(r,"Aprobado"), PartnerType=NullableText(r,"TipoSocio"), ExemptionDocumentType=NullableText(r,"EXO_TipoDocumento"), ExemptionNumber=NullableText(r,"EXO_Numero"), ExemptionInstitution=NullableText(r,"EXO_NombreInstitucion"), ExemptionIssuedOn=Date(r,"EXO_FechaEmision"), ExemptionPercent=Decimal(r,"EXO_PorcentajeCompra"), ExemptionExpiresOn=Date(r,"EXO_FechaVencimiento") };
    }
    private static void AddParameters(SqlCommand c, CustomerChangeRequest x)
    {
        Add(c,"@Sequence",SqlDbType.NVarChar,x.Sequence,50); Add(c,"@Code",SqlDbType.NVarChar,x.Code,50); Add(c,"@Name",SqlDbType.NVarChar,x.Name,200); Add(c,"@TaxId",SqlDbType.NVarChar,x.TaxId,20); Add(c,"@TaxResponsible",SqlDbType.NVarChar,x.TaxResponsible,200); Add(c,"@VisitSchedule",SqlDbType.NVarChar,x.VisitSchedule,200); Add(c,"@WebPassword",SqlDbType.NVarChar,x.WebPassword,512); Add(c,"@Phone1",SqlDbType.NVarChar,x.Phone1,50); Add(c,"@Phone2",SqlDbType.NVarChar,x.Phone2,50); Add(c,"@Address",SqlDbType.NVarChar,x.Address,500); Add(c,"@Email",SqlDbType.NVarChar,x.Email,254); Add(c,"@TradeName",SqlDbType.NVarChar,x.TradeName,200); Add(c,"@Latitude",SqlDbType.Decimal,x.Latitude); Add(c,"@Longitude",SqlDbType.Decimal,x.Longitude); Add(c,"@Agent",SqlDbType.NVarChar,x.AgentCode,50); Add(c,"@Province",SqlDbType.Int,x.ProvinceId); Add(c,"@Canton",SqlDbType.Int,x.CantonId); Add(c,"@District",SqlDbType.Int,x.DistrictId); Add(c,"@Neighborhood",SqlDbType.Int,x.NeighborhoodId); Add(c,"@State",SqlDbType.NVarChar,ToLegacyState(x.State),20); Add(c,"@IdentificationType",SqlDbType.Int,x.IdentificationType); Add(c,"@Date",SqlDbType.DateTime,x.RequestedAt.Date); Add(c,"@Time",SqlDbType.NVarChar,x.RequestedAt.ToString("HH:mm:ss",CultureInfo.InvariantCulture),20); Add(c,"@Approved",SqlDbType.Bit,x.Approved); Add(c,"@PartnerType",SqlDbType.NVarChar,x.PartnerType,20); Add(c,"@ExemptionType",SqlDbType.NVarChar,x.ExemptionDocumentType,20); Add(c,"@ExemptionNumber",SqlDbType.NVarChar,x.ExemptionNumber,100); Add(c,"@ExemptionInstitution",SqlDbType.NVarChar,x.ExemptionInstitution,200); Add(c,"@ExemptionIssued",SqlDbType.Date,x.ExemptionIssuedOn?.ToDateTime(TimeOnly.MinValue)); Add(c,"@ExemptionPercent",SqlDbType.Decimal,x.ExemptionPercent); Add(c,"@ExemptionExpires",SqlDbType.Date,x.ExemptionExpiresOn?.ToDateTime(TimeOnly.MinValue));
    }
    private static void Add(SqlCommand c,string name,SqlDbType type,object? value,int size=0) { var p=size>0?c.Parameters.Add(name,type,size):c.Parameters.Add(name,type); if(type==SqlDbType.Decimal){p.Precision=18;p.Scale=6;} p.Value=value??DBNull.Value; }
    private static string Text(SqlDataReader r,string n)=>Convert.ToString(r[n],CultureInfo.InvariantCulture)?.Trim()??"";
    private static string? NullableText(SqlDataReader r,string n)=>r[n] is DBNull?null:Text(r,n);
    private static T Value<T>(SqlDataReader r,string n)=>r[n] is DBNull?default!: (T)Convert.ChangeType(r[n],Nullable.GetUnderlyingType(typeof(T))??typeof(T),CultureInfo.InvariantCulture);
    private static int Number(SqlDataReader r,string n)=>int.TryParse(Text(r,n),out var x)?x:0;
    private static bool Boolean(SqlDataReader r,string n)=>r[n] is not DBNull && (r[n] is bool b?b:Number(r,n)!=0);
    private static decimal? Decimal(SqlDataReader r,string n)=>decimal.TryParse(Text(r,n),NumberStyles.Any,CultureInfo.InvariantCulture,out var x)?x:null;
    private static DateOnly? Date(SqlDataReader r,string n)=>r[n] is DBNull?null:DateOnly.FromDateTime(Convert.ToDateTime(r[n],CultureInfo.InvariantCulture));
    private static string ToLegacyState(CustomerChangeState state) => state switch { CustomerChangeState.New=>"Nuevo", CustomerChangeState.Close=>"Cerrar", CustomerChangeState.Modified=>"Modificado", CustomerChangeState.Internal=>"Interno", _=>throw new ArgumentOutOfRangeException(nameof(state)) };
    private static CustomerChangeState ParseState(string value) => value.Trim().ToUpperInvariant() switch { "NUEVO"=>CustomerChangeState.New, "CERRAR"=>CustomerChangeState.Close, "MODIFICADO"=>CustomerChangeState.Modified, "INTERNO"=>CustomerChangeState.Internal, _=>throw new DataException($"Estado de cliente no reconocido: {value}") };
}
