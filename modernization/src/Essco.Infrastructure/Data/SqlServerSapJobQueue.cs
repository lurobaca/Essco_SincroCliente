using System.Data;
using System.Globalization;
using Essco.Application;
using Essco.Domain;
using Essco.SapBridge.Contracts;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerSapJobQueue(string connectionString, int commandTimeoutSeconds) : ISapJobQueue
{
    private const string Columns = "[JobId],[OperationType],[Company],[RequestedBy],[Payload],[Status],[Attempts],[CreatedAt],[ProcessedAt],[ExternalId],[SanitizedError]";
    public async ValueTask<SapJob> EnqueueAsync(CreateSapJobRequest request, CancellationToken token)
    {
        var id = Guid.NewGuid(); const string insert = """
            INSERT INTO [dbo].[WebSapJobs]([JobId],[IdempotencyKey],[OperationType],[Company],[RequestedBy],[Payload],[Status],[Attempts],[CreatedAt],[NextAttemptAt])
            VALUES(@Id,@Key,@Operation,@Company,@RequestedBy,@Payload,'Pending',0,SYSUTCDATETIME(),SYSUTCDATETIME());
            """;
        await using var connection = await OpenAsync(token); await using var command = Command(insert, connection); AddRequest(command, id, request);
        try { await command.ExecuteNonQueryAsync(token); } catch (SqlException ex) when (ex.Number is 2601 or 2627) { return await GetByKeyAsync(connection, request.IdempotencyKey, token) ?? throw new DataException("La clave idempotente existe pero no pudo recuperarse."); }
        return await GetByIdAsync(connection, id, token) ?? throw new DataException("No fue posible recuperar el trabajo SAP creado.");
    }
    public async ValueTask<SapJob?> ClaimNextAsync(CancellationToken token)
    {
        var sql = $"""
            ;WITH candidate AS
            (SELECT TOP(1) * FROM [dbo].[WebSapJobs] WITH(UPDLOCK,READPAST,ROWLOCK)
             WHERE (([Status] IN('Pending','RetryableFailure') AND [NextAttemptAt]<=SYSUTCDATETIME()) OR ([Status]='Processing' AND [LockedAt]<DATEADD(minute,-10,SYSUTCDATETIME())))
             ORDER BY [CreatedAt],[JobId])
            UPDATE candidate SET [Status]='Processing',[Attempts]=[Attempts]+1,[LockedAt]=SYSUTCDATETIME(),[ProcessedAt]=NULL,[SanitizedError]=NULL
            OUTPUT INSERTED.[JobId],INSERTED.[OperationType],INSERTED.[Company],INSERTED.[RequestedBy],INSERTED.[Payload],INSERTED.[Status],INSERTED.[Attempts],INSERTED.[CreatedAt],INSERTED.[ProcessedAt],INSERTED.[ExternalId],INSERTED.[SanitizedError];
            """;
        await using var connection = await OpenAsync(token); await using var command = Command(sql, connection); await using var reader = await command.ExecuteReaderAsync(token); return await reader.ReadAsync(token) ? Map(reader) : null;
    }
    public async ValueTask CompleteAsync(Guid jobId, string externalId, CancellationToken token)
    {
        const string sql = "UPDATE [dbo].[WebSapJobs] SET [Status]='Completed',[ExternalId]=@ExternalId,[SanitizedError]=NULL,[ProcessedAt]=SYSUTCDATETIME(),[LockedAt]=NULL WHERE [JobId]=@Id AND [Status]='Processing'";
        await ExecuteTransitionAsync(sql, jobId, externalId, null, token);
    }
    public async ValueTask FailAsync(Guid jobId, string sanitizedError, bool retryable, CancellationToken token)
    {
        const string sql = """
            UPDATE [dbo].[WebSapJobs] SET [Status]=@Status,[SanitizedError]=@Error,[ProcessedAt]=SYSUTCDATETIME(),[LockedAt]=NULL,
            [NextAttemptAt]=CASE WHEN @Retryable=1 THEN DATEADD(second,CASE WHEN POWER(CAST(2 AS bigint),[Attempts])>300 THEN 300 ELSE POWER(CAST(2 AS bigint),[Attempts]) END,SYSUTCDATETIME()) ELSE [NextAttemptAt] END
            WHERE [JobId]=@Id AND [Status]='Processing';
            """;
        await using var connection = await OpenAsync(token); await using var command = Command(sql, connection); command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = jobId; command.Parameters.Add("@Status", SqlDbType.VarChar, 32).Value = retryable ? "RetryableFailure" : "PermanentFailure"; command.Parameters.Add("@Error", SqlDbType.NVarChar, 1000).Value = Sanitize(sanitizedError); command.Parameters.Add("@Retryable", SqlDbType.Bit).Value = retryable;
        if (await command.ExecuteNonQueryAsync(token) != 1) throw new DBConcurrencyException($"El trabajo SAP {jobId} ya no está en proceso.");
    }
    public async ValueTask<IReadOnlyCollection<SapJob>> GetSnapshotAsync(CancellationToken token)
    {
        await using var connection = await OpenAsync(token); await using var command = Command($"SELECT TOP(200) {Columns} FROM [dbo].[WebSapJobs] ORDER BY [CreatedAt] DESC", connection); var result = new List<SapJob>(); await using var reader = await command.ExecuteReaderAsync(token); while (await reader.ReadAsync(token)) result.Add(Map(reader)); return result;
    }
    private async Task ExecuteTransitionAsync(string sql, Guid id, string? externalId, string? error, CancellationToken token) { await using var connection = await OpenAsync(token); await using var command = Command(sql, connection); command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id; command.Parameters.Add("@ExternalId", SqlDbType.NVarChar, 200).Value = (object?)externalId ?? DBNull.Value; if (await command.ExecuteNonQueryAsync(token) != 1) throw new DBConcurrencyException($"El trabajo SAP {id} ya no está en proceso."); }
    private async ValueTask<SapJob?> GetByKeyAsync(SqlConnection connection, string key, CancellationToken token) { await using var command = Command($"SELECT {Columns} FROM [dbo].[WebSapJobs] WHERE [IdempotencyKey]=@Key", connection); command.Parameters.Add("@Key", SqlDbType.NVarChar, 200).Value = key; await using var reader = await command.ExecuteReaderAsync(token); return await reader.ReadAsync(token) ? Map(reader) : null; }
    private async ValueTask<SapJob?> GetByIdAsync(SqlConnection connection, Guid id, CancellationToken token) { await using var command = Command($"SELECT {Columns} FROM [dbo].[WebSapJobs] WHERE [JobId]=@Id", connection); command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id; await using var reader = await command.ExecuteReaderAsync(token); return await reader.ReadAsync(token) ? Map(reader) : null; }
    private async ValueTask<SqlConnection> OpenAsync(CancellationToken token) { var c = new SqlConnection(connectionString); await c.OpenAsync(token); return c; }
    private SqlCommand Command(string sql, SqlConnection c) => new(sql, c) { CommandTimeout = commandTimeoutSeconds };
    private static void AddRequest(SqlCommand c, Guid id, CreateSapJobRequest x) { c.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id; c.Parameters.Add("@Key", SqlDbType.NVarChar, 200).Value = x.IdempotencyKey; c.Parameters.Add("@Operation", SqlDbType.NVarChar, 100).Value = x.OperationType; c.Parameters.Add("@Company", SqlDbType.NVarChar, 100).Value = x.Company; c.Parameters.Add("@RequestedBy", SqlDbType.NVarChar, 256).Value = x.RequestedBy; c.Parameters.Add("@Payload", SqlDbType.NVarChar, -1).Value = x.Payload; }
    private static SapJob Map(SqlDataReader r) => SapJob.Restore((Guid)r["JobId"], Text(r, "OperationType"), Text(r, "Company"), Text(r, "RequestedBy"), Text(r, "Payload"), Enum.Parse<SapJobStatus>(Text(r, "Status")), Convert.ToInt32(r["Attempts"], CultureInfo.InvariantCulture), (DateTimeOffset)r["CreatedAt"], r["ProcessedAt"] is DBNull ? null : (DateTimeOffset)r["ProcessedAt"], NullableText(r, "ExternalId"), NullableText(r, "SanitizedError"));
    private static string Sanitize(string value) => value.Replace("\r", " ", StringComparison.Ordinal).Replace("\n", " ", StringComparison.Ordinal).Trim()[..Math.Min(1000, value.Trim().Length)];
    private static string Text(SqlDataReader r, string n) => Convert.ToString(r[n], CultureInfo.InvariantCulture)?.Trim() ?? "";
    private static string? NullableText(SqlDataReader r, string n) => r[n] is DBNull ? null : Text(r, n);
}
