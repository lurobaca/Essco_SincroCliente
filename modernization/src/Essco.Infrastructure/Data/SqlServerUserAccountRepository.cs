using System.Data;
using Essco.Application.Security;
using Essco.Domain.Security;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerUserAccountRepository(
    string connectionString,
    int commandTimeoutSeconds) : IUserAccountRepository
{
    public async ValueTask<UserAccount?> FindByNormalizedUsernameAsync(
        string normalizedUsername,
        CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT TOP (1)
                u.[id],
                u.[Usuario],
                COALESCE(NULLIF(u.[Nombre], ''), u.[Usuario]) AS [DisplayName],
                COALESCE(NULLIF(u.[Puesto], ''), 'SinRol') AS [Role],
                CASE WHEN COALESCE(s.[CredentialFormat], 0) = 0 THEN COALESCE(u.[Password], '') ELSE s.[CredentialHash] END AS [Credential],
                COALESCE(s.[CredentialFormat], 0) AS [CredentialFormat],
                CASE WHEN s.[UserId] IS NULL
                    THEN CASE WHEN CONVERT(nvarchar(10), u.[Cambiar]) = '1' THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END
                    ELSE s.[MustChangePassword]
                END AS [MustChangePassword],
                COALESCE(s.[FailedAccessCount], 0) AS [FailedAccessCount],
                s.[LockedUntil]
            FROM [dbo].[Users] AS u
            LEFT JOIN [dbo].[Web_UserSecurity] AS s ON s.[UserId] = u.[id]
            WHERE UPPER(LTRIM(RTRIM(u.[Usuario]))) = @NormalizedUsername;
            """;

        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        await using var command = new SqlCommand(sql, connection) { CommandTimeout = commandTimeoutSeconds };
        command.Parameters.Add("@NormalizedUsername", SqlDbType.NVarChar, 256).Value = normalizedUsername;

        await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow, cancellationToken);
        if (!await reader.ReadAsync(cancellationToken)) return null;

        return new UserAccount(
            checked(Convert.ToInt32(reader.GetValue(reader.GetOrdinal("id")), System.Globalization.CultureInfo.InvariantCulture)),
            reader.GetString(reader.GetOrdinal("Usuario")),
            reader.GetString(reader.GetOrdinal("DisplayName")),
            reader.GetString(reader.GetOrdinal("Role")),
            reader.GetString(reader.GetOrdinal("Credential")),
            (CredentialFormat)reader.GetInt32(reader.GetOrdinal("CredentialFormat")),
            reader.GetBoolean(reader.GetOrdinal("MustChangePassword")),
            reader.GetInt32(reader.GetOrdinal("FailedAccessCount")),
            reader.IsDBNull(reader.GetOrdinal("LockedUntil"))
                ? null
                : reader.GetFieldValue<DateTimeOffset>(reader.GetOrdinal("LockedUntil")));
    }

    public async ValueTask SaveAuthenticationStateAsync(UserAccount account, CancellationToken cancellationToken)
    {
        const string sql = """
            MERGE [dbo].[Web_UserSecurity] WITH (HOLDLOCK) AS target
            USING (SELECT @UserId AS [UserId]) AS source
            ON target.[UserId] = source.[UserId]
            WHEN MATCHED THEN UPDATE SET
                [CredentialHash] = @CredentialHash,
                [CredentialFormat] = @CredentialFormat,
                [MustChangePassword] = @MustChangePassword,
                [FailedAccessCount] = @FailedAccessCount,
                [LockedUntil] = @LockedUntil,
                [UpdatedAt] = SYSUTCDATETIME()
            WHEN NOT MATCHED THEN INSERT
                ([UserId], [CredentialHash], [CredentialFormat], [MustChangePassword], [FailedAccessCount], [LockedUntil], [UpdatedAt])
            VALUES
                (@UserId, @CredentialHash, @CredentialFormat, @MustChangePassword, @FailedAccessCount, @LockedUntil, SYSUTCDATETIME());
            """;

        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, cancellationToken);
        await using var command = new SqlCommand(sql, connection, transaction) { CommandTimeout = commandTimeoutSeconds };
        command.Parameters.Add("@UserId", SqlDbType.Int).Value = account.Id;
        command.Parameters.Add("@CredentialHash", SqlDbType.NVarChar, 512).Value =
            account.CredentialFormat == CredentialFormat.Pbkdf2Sha512 ? account.Credential : DBNull.Value;
        command.Parameters.Add("@CredentialFormat", SqlDbType.TinyInt).Value = (byte)account.CredentialFormat;
        command.Parameters.Add("@MustChangePassword", SqlDbType.Bit).Value = account.MustChangePassword;
        command.Parameters.Add("@FailedAccessCount", SqlDbType.Int).Value = account.FailedAccessCount;
        command.Parameters.Add("@LockedUntil", SqlDbType.DateTimeOffset).Value =
            account.LockedUntil is null ? DBNull.Value : account.LockedUntil.Value;

        await command.ExecuteNonQueryAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}
