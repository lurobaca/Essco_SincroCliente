using System.Data;
using Essco.Application.Auditing;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerAuditSink(string connectionString, int commandTimeoutSeconds) : IAuditSink
{
    public async ValueTask WriteAsync(AuditEvent item, CancellationToken cancellationToken)
    {
        const string sql = """
            INSERT INTO [dbo].[Web_AuditLog]
                ([EventId], [OccurredAt], [UserId], [Username], [Company], [Operation], [EntityType],
                 [EntityId], [Outcome], [CorrelationId], [IpAddress])
            VALUES
                (@EventId, @OccurredAt, @UserId, @Username, @Company, @Operation, @EntityType,
                 @EntityId, @Outcome, @CorrelationId, @IpAddress);
            """;

        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        await using var command = new SqlCommand(sql, connection) { CommandTimeout = commandTimeoutSeconds };
        Add(command, "@EventId", SqlDbType.UniqueIdentifier, item.EventId);
        Add(command, "@OccurredAt", SqlDbType.DateTimeOffset, item.OccurredAt);
        Add(command, "@UserId", SqlDbType.Int, item.UserId);
        Add(command, "@Username", SqlDbType.NVarChar, item.Username, 256);
        Add(command, "@Company", SqlDbType.NVarChar, item.Company, 128);
        Add(command, "@Operation", SqlDbType.NVarChar, item.Operation, 128);
        Add(command, "@EntityType", SqlDbType.NVarChar, item.EntityType, 128);
        Add(command, "@EntityId", SqlDbType.NVarChar, item.EntityId, 256);
        Add(command, "@Outcome", SqlDbType.NVarChar, item.Outcome, 64);
        Add(command, "@CorrelationId", SqlDbType.NVarChar, item.CorrelationId, 128);
        Add(command, "@IpAddress", SqlDbType.NVarChar, item.IpAddress, 64);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    private static void Add(SqlCommand command, string name, SqlDbType type, object? value, int? size = null)
    {
        var parameter = size is null ? command.Parameters.Add(name, type) : command.Parameters.Add(name, type, size.Value);
        parameter.Value = value ?? DBNull.Value;
    }
}
