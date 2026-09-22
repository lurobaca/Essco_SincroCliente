using System.Data;
using Essco.Application.Payroll;
using Microsoft.Data.SqlClient;
namespace Essco.Infrastructure.Data;

public sealed class SqlServerPayrollJournalRepository(string connectionString, int timeout) : IPayrollJournalRepository
{
    public async ValueTask<PayrollJournal?> GetAsync(int number, CancellationToken t)
    {
        await using var c = new SqlConnection(connectionString);
        await c.OpenAsync(t);
        string memo;
        await using (var h = new SqlCommand("SELECT [Comentario] FROM [dbo].[Planilla] WHERE [Consecutivo]=@Number AND [Estado]<>1", c) { CommandTimeout = timeout })
        {
            h.Parameters.Add("@Number", SqlDbType.Int).Value = number;
            var value = await h.ExecuteScalarAsync(t);
            if (value is null) return null;
            memo = value is DBNull ? "" : Convert.ToString(value) ?? "";
        }
        var lines = new List<PayrollJournalLine>();
        await using var cmd = new SqlCommand("SP_CrearAsientoPlanilla", c) { CommandType = CommandType.StoredProcedure, CommandTimeout = timeout };
        cmd.Parameters.Add("@IdPlanilla", SqlDbType.Int).Value = number;
        var code = cmd.Parameters.Add("@pCodError", SqlDbType.Int);
        code.Direction = ParameterDirection.Output;
        var message = cmd.Parameters.Add("@pMensajeError", SqlDbType.VarChar, 300);
        message.Direction = ParameterDirection.Output;
        await using (var reader = await cmd.ExecuteReaderAsync(t))
        {
            while (await reader.ReadAsync(t))
                lines.Add(new(Convert.ToString(reader["NumeroCuenta"])?.Trim() ?? "",
                    reader["Debit"] is DBNull ? 0 : Convert.ToDecimal(reader["Debit"]),
                    reader["Credit"] is DBNull ? 0 : Convert.ToDecimal(reader["Credit"])));
        }
        if (code.Value is null or DBNull || Convert.ToInt32(code.Value) != 0)
            throw new DataException("El procedimiento de asiento no confirmó un resultado exitoso.");
        return new(number, memo, lines);
    }
}
