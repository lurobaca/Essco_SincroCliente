using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
namespace Essco.Portal;

public sealed record PortalUser(Guid Id, string Name);
public sealed record Organization(Guid Id, string Name, string Role);
public sealed record PortalApplication(string Code, string Name, string Description, bool Enabled);

public sealed class PortalStore(IConfiguration configuration)
{
    private readonly PasswordHasher<object> hasher = new(Options.Create(new PasswordHasherOptions { IterationCount = 210000 }));
    private readonly string dummyHash = new PasswordHasher<object>().HashPassword(new(), Guid.NewGuid().ToString());
    public bool Configured => !string.IsNullOrWhiteSpace(configuration.GetConnectionString("PortalSqlServer"));
    private async Task<SqlConnection> Open(CancellationToken token)
    {
        var connection = new SqlConnection(configuration.GetConnectionString("PortalSqlServer"));
        try { await connection.OpenAsync(token); return connection; }
        catch { await connection.DisposeAsync(); throw; }
    }
    public async Task<PortalUser?> Authenticate(string email, string password, CancellationToken token)
    {
        if (!Configured) return null;
        await using var connection = await Open(token);
        await using var tx = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        Guid id = Guid.Empty; string name = "", hash = dummyHash;
        bool active = false, locked = false; int attempts = 0;
        await using (var cmd = new SqlCommand("""
            SELECT Id,Nombre,PasswordHash,Activo,IntentosFallidos,
            CASE WHEN BloqueadoHastaUtc>SYSUTCDATETIME() THEN 1 ELSE 0 END AS Locked
            FROM Identidad.Usuarios WITH(UPDLOCK,HOLDLOCK) WHERE CorreoNormalizado=@Email
            """, connection, tx))
        {
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 254).Value = email.Trim().ToUpperInvariant();
            await using var reader = await cmd.ExecuteReaderAsync(token);
            if (await reader.ReadAsync(token))
            {
                id = reader.GetGuid(0); name = reader.GetString(1); hash = reader.GetString(2);
                active = reader.GetBoolean(3); attempts = reader.GetInt32(4); locked = reader.GetInt32(5) == 1;
            }
        }
        var verified = hasher.VerifyHashedPassword(new(), hash, password) != PasswordVerificationResult.Failed;
        if (id == Guid.Empty || !active || locked) return null;
        await using var update = new SqlCommand(verified ? """
            UPDATE Identidad.Usuarios SET IntentosFallidos=0,BloqueadoHastaUtc=NULL WHERE Id=@Id;
            INSERT Auditoria.Eventos(UsuarioId,Accion) VALUES(@Id,'portal.login');
            """ : """
            UPDATE Identidad.Usuarios SET IntentosFallidos=@Attempts,
            BloqueadoHastaUtc=CASE WHEN @Attempts>=5 THEN DATEADD(minute,15,SYSUTCDATETIME()) ELSE NULL END WHERE Id=@Id;
            """, connection, tx);
        update.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
        update.Parameters.Add("@Attempts", SqlDbType.Int).Value = attempts >= 5 ? 1 : attempts + 1;
        await update.ExecuteNonQueryAsync(token);
        await tx.CommitAsync(token);
        return verified ? new(id, name) : null;
    }

    public async Task<IReadOnlyList<Organization>> Organizations(Guid userId, CancellationToken token)
    {
        if (!Configured) return [];
        await using var connection = await Open(token);
        await using var cmd = new SqlCommand("""
            SELECT O.Id,O.Nombre,M.Rol FROM Portal.Organizaciones O
            JOIN Identidad.Membresias M ON M.OrganizacionId=O.Id
            JOIN Identidad.Usuarios U ON U.Id=M.UsuarioId
            WHERE M.UsuarioId=@User AND M.Activa=1 AND O.Activa=1 AND U.Activo=1 ORDER BY O.Nombre
            """, connection);
        cmd.Parameters.Add("@User", SqlDbType.UniqueIdentifier).Value = userId;
        var list = new List<Organization>();
        await using var reader = await cmd.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token)) list.Add(new(reader.GetGuid(0),reader.GetString(1),reader.GetString(2)));
        return list;
    }
    public async Task<IReadOnlyList<PortalApplication>> Applications(Guid userId, Guid organizationId, CancellationToken token)
    {
        await using var connection = await Open(token);
        await using var cmd = new SqlCommand("""
            SELECT A.Codigo,A.Nombre,A.Descripcion,
            CAST(CASE WHEN OA.Habilitada=1 AND (M.Rol='Administrador' OR X.UsuarioId IS NOT NULL) THEN 1 ELSE 0 END AS bit)
            FROM Identidad.Membresias M
            JOIN Identidad.Usuarios U ON U.Id=M.UsuarioId AND U.Activo=1
            JOIN Portal.Organizaciones O ON O.Id=M.OrganizacionId AND O.Activa=1
            JOIN Portal.OrganizacionAplicaciones OA ON OA.OrganizacionId=M.OrganizacionId
            JOIN Portal.Aplicaciones A ON A.Codigo=OA.AplicacionCodigo AND A.Activa=1
            LEFT JOIN Portal.Accesos X ON X.OrganizacionId=M.OrganizacionId AND X.UsuarioId=M.UsuarioId AND X.AplicacionCodigo=A.Codigo
            WHERE M.UsuarioId=@User AND M.OrganizacionId=@Org AND M.Activa=1 ORDER BY A.Nombre
            """, connection);
        cmd.Parameters.Add("@User", SqlDbType.UniqueIdentifier).Value = userId;
        cmd.Parameters.Add("@Org", SqlDbType.UniqueIdentifier).Value = organizationId;
        var list = new List<PortalApplication>();
        await using var reader = await cmd.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token)) list.Add(new(reader.GetString(0),reader.GetString(1),reader.GetString(2),reader.GetBoolean(3)));
        return list;
    }
    // Local, interactive initialization only; not exposed as an HTTP endpoint.
    public async Task Provision(string email, string name, string organization, string password)
    {
        await using var connection = await Open(default);
        await using var tx = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable);
        await using var cmd = new SqlCommand("""
            IF EXISTS(SELECT 1 FROM Identidad.Usuarios WITH(UPDLOCK,HOLDLOCK))
                THROW 51000,'La inicialización ya se realizó. Utilice el futuro flujo de invitaciones.',1;
            INSERT Identidad.Usuarios(Id,CorreoNormalizado,Nombre,PasswordHash) VALUES(@User,@Email,@Name,@Hash);
            INSERT Portal.Organizaciones(Id,Nombre) VALUES(@Org,@Organization);
            INSERT Identidad.Membresias(OrganizacionId,UsuarioId,Rol) VALUES(@Org,@User,'Administrador');
            INSERT Portal.OrganizacionAplicaciones(OrganizacionId,AplicacionCodigo,Habilitada) VALUES(@Org,'syncro-cliente',0);
            INSERT Auditoria.Eventos(OrganizacionId,UsuarioId,Accion) VALUES(@Org,@User,'portal.initialize');
            """, connection, tx);
        cmd.Parameters.Add("@User", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
        cmd.Parameters.Add("@Org", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar,254).Value = email.Trim().ToUpperInvariant();
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar,200).Value = name.Trim();
        cmd.Parameters.Add("@Organization", SqlDbType.NVarChar,200).Value = organization.Trim();
        cmd.Parameters.Add("@Hash", SqlDbType.NVarChar,512).Value = hasher.HashPassword(new(),password);
        await cmd.ExecuteNonQueryAsync();
        await tx.CommitAsync();
    }
}
