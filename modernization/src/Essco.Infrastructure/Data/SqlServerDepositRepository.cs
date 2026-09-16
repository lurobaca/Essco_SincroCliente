using System.Data;
using Essco.Application.Treasury;
using Essco.Domain.Treasury;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

public sealed class SqlServerDepositRepository(string connectionString, int timeout) : IDepositRepository
{
    private const string SelectColumns = "[DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],[DPMONTO],[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_TIPO_LIQ],[DP_BOLETA],[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]";
    public async ValueTask<IReadOnlyCollection<string>> ListBanksAsync(CancellationToken token)
    {
        await using var connection = await OpenAsync(token);
        await using var command = Command("SELECT [BankName] FROM [dbo].[Bancos] ORDER BY [BankName]", connection);
        var result = new List<string>();
        await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token)) result.Add(Convert.ToString(reader["BankName"])?.Trim() ?? "");
        return result.Where(x => x.Length > 0).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
    }

    public async ValueTask<IReadOnlyCollection<Deposit>> ListAsync(DepositFilter filter, CancellationToken token)
    {
        var conditions = new List<string>();
        await using var connection = await OpenAsync(token); await using var command = Command("", connection);
        if (filter.From is not null) { conditions.Add("[DPFECHA]>=@From"); command.Parameters.Add("@From", SqlDbType.Date).Value = filter.From.Value.ToDateTime(TimeOnly.MinValue); }
        if (filter.To is not null) { conditions.Add("[DPFECHA]<DATEADD(day,1,@To)"); command.Parameters.Add("@To", SqlDbType.Date).Value = filter.To.Value.ToDateTime(TimeOnly.MinValue); }
        AddContains(conditions, command, "[DPAGENTE]", "@Employee", filter.EmployeeCode);
        AddContains(conditions, command, "[DPCODIGO]", "@Number", filter.Number);
        if (filter.Consecutive is not null) { conditions.Add("[DPCONSECUTIVO]=@Consecutive"); command.Parameters.Add("@Consecutive", SqlDbType.Int).Value = filter.Consecutive.Value; }
        if (filter.Uploaded is not null) { conditions.Add("[DP_SUBIDO]=@Uploaded"); command.Parameters.Add("@Uploaded", SqlDbType.Bit).Value = filter.Uploaded.Value; }
        if (!string.IsNullOrWhiteSpace(filter.LiquidationType)) { conditions.Add("[DP_TIPO_LIQ]=@Type"); command.Parameters.Add("@Type", SqlDbType.NVarChar, 20).Value = filter.LiquidationType.Trim(); }
        if (!filter.IncludeAnnulled) conditions.Add("ISNULL([DP_ANULADO],0)<>1");
        command.CommandText = $"SELECT {SelectColumns} FROM [dbo].[Depositos]{(conditions.Count == 0 ? "" : " WHERE " + string.Join(" AND ", conditions))} ORDER BY [DPCONSECUTIVO] DESC";
        var result = new List<Deposit>(); await using var reader = await command.ExecuteReaderAsync(token); while (await reader.ReadAsync(token)) result.Add(Read(reader)); return result;
    }
    public async ValueTask<DepositWriteResult> CreateAsync(Deposit deposit, CancellationToken token)
    {
        await using var connection = await OpenAsync(token); await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        try
        {
            var duplicate = await DuplicateErrorAsync(deposit, null, connection, transaction, token); if (duplicate is not null) return await Rollback(transaction, duplicate, token);
            await using var next = Command("SELECT [ConseDepositos] FROM [dbo].[Consecutivos_Liquidaciones] WITH (UPDLOCK,HOLDLOCK)", connection, transaction);
            var consecutive = Convert.ToInt32(await next.ExecuteScalarAsync(token));
            const string sql = "INSERT INTO [dbo].[Depositos]([DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],[DPMONTO],[DPAGENTE],[DPOBS],[DPLIQUIDACION],[DP_TIPO_LIQ],[DPFECHA_CONTABLE],[DP_ANULADO],[DP_SUBIDO]) VALUES(@Consecutive,@Number,@Date,@Bank,@Amount,@Employee,@Notes,@Liquidation,@Type,@AccountingDate,0,0)";
            await using (var insert = Command(sql, connection, transaction)) { AddParameters(insert, deposit with { Consecutive = consecutive }); await insert.ExecuteNonQueryAsync(token); }
            await using (var increase = Command("UPDATE [dbo].[Consecutivos_Liquidaciones] SET [ConseDepositos]=@Next", connection, transaction)) { increase.Parameters.Add("@Next", SqlDbType.Int).Value = consecutive + 1; await increase.ExecuteNonQueryAsync(token); }
            await transaction.CommitAsync(token); return new(true, consecutive);
        }
        catch { await transaction.RollbackAsync(token); throw; }
    }
    public async ValueTask<DepositWriteResult> UpdateAsync(Deposit deposit, CancellationToken token)
    {
        await using var connection = await OpenAsync(token); await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.Serializable, token);
        try
        {
            await using (var state = Command("SELECT [DP_ANULADO] FROM [dbo].[Depositos] WITH (UPDLOCK,HOLDLOCK) WHERE [DPCONSECUTIVO]=@Consecutive", connection, transaction)) { state.Parameters.Add("@Consecutive", SqlDbType.Int).Value = deposit.Consecutive; var value = await state.ExecuteScalarAsync(token); if (value is null) return await Rollback(transaction, "El depósito ya no existe.", token); if (Convert.ToInt32(value) == 1) return await Rollback(transaction, "Un depósito anulado no se puede modificar.", token); }
            var duplicate = await DuplicateErrorAsync(deposit, deposit.Consecutive, connection, transaction, token); if (duplicate is not null) return await Rollback(transaction, duplicate, token);
            const string sql = "UPDATE [dbo].[Depositos] SET [DPCODIGO]=@Number,[DPFECHA]=@Date,[DPBANCO]=@Bank,[DPMONTO]=@Amount,[DPAGENTE]=@Employee,[DPOBS]=@Notes,[DPLIQUIDACION]=@Liquidation,[DP_TIPO_LIQ]=@Type,[DPFECHA_CONTABLE]=@AccountingDate,[DP_SUBIDO]=@Uploaded WHERE [DPCONSECUTIVO]=@Consecutive AND ISNULL([DP_ANULADO],0)<>1";
            await using var update = Command(sql, connection, transaction); AddParameters(update, deposit); var changed = await update.ExecuteNonQueryAsync(token); await transaction.CommitAsync(token); return new(changed == 1, deposit.Consecutive, changed == 1 ? null : "El depósito ya no existe.");
        }
        catch { await transaction.RollbackAsync(token); throw; }
    }
    public ValueTask<bool> AnnulAsync(int consecutive, CancellationToken token) => ExecuteStateAsync("UPDATE [dbo].[Depositos] SET [DP_ANULADO]=1 WHERE [DPCONSECUTIVO]=@Consecutive AND ISNULL([DP_ANULADO],0)<>1", consecutive, token);
    public async ValueTask<bool> LinkLiquidationAsync(int consecutive, string liquidationNumber, string liquidationType, CancellationToken token)
    {
        await using var connection = await OpenAsync(token); await using var command = Command("UPDATE [dbo].[Depositos] SET [DPLIQUIDACION]=@Liquidation,[DP_TIPO_LIQ]=@Type WHERE [DPCONSECUTIVO]=@Consecutive AND ISNULL([DP_ANULADO],0)<>1", connection); command.Parameters.Add("@Consecutive", SqlDbType.Int).Value = consecutive; command.Parameters.Add("@Liquidation", SqlDbType.NVarChar, 50).Value = liquidationNumber; command.Parameters.Add("@Type", SqlDbType.NVarChar, 20).Value = liquidationType; return await command.ExecuteNonQueryAsync(token) == 1;
    }
    public ValueTask<bool> MarkUploadedAsync(int consecutive, CancellationToken token) => ExecuteStateAsync("UPDATE [dbo].[Depositos] SET [DP_BOLETA]=0,[DP_SUBIDO]=1 WHERE [DPCONSECUTIVO]=@Consecutive AND ISNULL([DP_ANULADO],0)<>1", consecutive, token);
    private async ValueTask<bool> ExecuteStateAsync(string sql, int consecutive, CancellationToken token) { await using var connection = await OpenAsync(token); await using var command = Command(sql, connection); command.Parameters.Add("@Consecutive", SqlDbType.Int).Value = consecutive; return await command.ExecuteNonQueryAsync(token) == 1; }
    private async ValueTask<string?> DuplicateErrorAsync(Deposit deposit, int? excluding, SqlConnection connection, SqlTransaction transaction, CancellationToken token)
    {
        var sql = "SELECT [DPLIQUIDACION],[DPBANCO] FROM [dbo].[Depositos] WITH (UPDLOCK,HOLDLOCK) WHERE [DPCODIGO]=@Number AND (@Exclude IS NULL OR [DPCONSECUTIVO]<>@Exclude)";
        await using var command = Command(sql, connection, transaction); command.Parameters.Add("@Number", SqlDbType.NVarChar, 100).Value = deposit.Number.Trim(); command.Parameters.Add("@Bank", SqlDbType.NVarChar, 200).Value = deposit.Bank.Trim(); command.Parameters.Add("@Exclude", SqlDbType.Int).Value = (object?)excluding ?? DBNull.Value;
        string? linkedLiquidation = null;
        await using var reader = await command.ExecuteReaderAsync(token);
        while (await reader.ReadAsync(token))
        {
            var bank = Convert.ToString(reader["DPBANCO"])?.Trim();
            var liquidation = Convert.ToString(reader["DPLIQUIDACION"])?.Trim();
            if (string.Equals(bank, deposit.Bank.Trim(), StringComparison.OrdinalIgnoreCase)) return "Ya existe ese número de depósito para el banco seleccionado.";
            if (!string.IsNullOrWhiteSpace(liquidation)) linkedLiquidation ??= liquidation;
        }
        return linkedLiquidation is null ? null : $"El número de depósito ya está asociado a la liquidación {linkedLiquidation}.";
    }
    private static Deposit Read(SqlDataReader r){var date=DateOnly.FromDateTime(Convert.ToDateTime(r["DPFECHA"]));return new(){Consecutive=Convert.ToInt32(r["DPCONSECUTIVO"]),Number=Text(r,"DPCODIGO"),Date=date,Bank=Text(r,"DPBANCO"),Amount=Convert.ToDecimal(r["DPMONTO"]),EmployeeCode=Text(r,"DPAGENTE"),Notes=Text(r,"DPOBS"),LiquidationNumber=Text(r,"DPLIQUIDACION"),LiquidationType=Text(r,"DP_TIPO_LIQ"),AccountingDate=r["DPFECHA_CONTABLE"] is DBNull?date:DateOnly.FromDateTime(Convert.ToDateTime(r["DPFECHA_CONTABLE"])),HasReceipt=Bool(r,"DP_BOLETA"),IsUploaded=Bool(r,"DP_SUBIDO"),IsAnnulled=Bool(r,"DP_ANULADO")};}
    private static bool Bool(SqlDataReader r,string n)=>r[n] is not DBNull&&Convert.ToInt32(r[n])!=0; private static string Text(SqlDataReader r,string n)=>Convert.ToString(r[n])?.Trim()??"";
    private static void AddParameters(SqlCommand c,Deposit x){c.Parameters.Add("@Consecutive",SqlDbType.Int).Value=x.Consecutive;c.Parameters.Add("@Number",SqlDbType.NVarChar,100).Value=x.Number.Trim();c.Parameters.Add("@Date",SqlDbType.Date).Value=x.Date.ToDateTime(TimeOnly.MinValue);c.Parameters.Add("@Bank",SqlDbType.NVarChar,200).Value=x.Bank.Trim();c.Parameters.Add("@Amount",SqlDbType.Decimal).Value=x.Amount;c.Parameters["@Amount"].Precision=19;c.Parameters["@Amount"].Scale=4;c.Parameters.Add("@Employee",SqlDbType.NVarChar,50).Value=x.EmployeeCode.Trim();c.Parameters.Add("@Notes",SqlDbType.NVarChar,1000).Value=x.Notes.Trim();c.Parameters.Add("@Liquidation",SqlDbType.NVarChar,50).Value=x.LiquidationNumber.Trim();c.Parameters.Add("@Type",SqlDbType.NVarChar,20).Value=x.LiquidationType.Trim();c.Parameters.Add("@AccountingDate",SqlDbType.Date).Value=x.AccountingDate.ToDateTime(TimeOnly.MinValue);c.Parameters.Add("@Uploaded",SqlDbType.Bit).Value=x.IsUploaded;}
    private static void AddContains(ICollection<string> conditions,SqlCommand c,string column,string parameter,string? value){if(string.IsNullOrWhiteSpace(value))return;conditions.Add($"{column} LIKE {parameter}");c.Parameters.Add(parameter,SqlDbType.NVarChar,100).Value=$"%{value.Trim()}%";}
    private static async ValueTask<DepositWriteResult> Rollback(SqlTransaction transaction,string error,CancellationToken token){await transaction.RollbackAsync(token);return new(false,0,error);}
    private async ValueTask<SqlConnection> OpenAsync(CancellationToken t){var c=new SqlConnection(connectionString);await c.OpenAsync(t);return c;} private SqlCommand Command(string sql,SqlConnection c,SqlTransaction? transaction=null)=>new(sql,c,transaction){CommandTimeout=timeout};
}
