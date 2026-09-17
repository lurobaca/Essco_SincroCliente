namespace Essco.Application.Payroll;

public static class PayrollJournalValidation
{
    public static string? Error(PayrollJournal journal)
    {
        if (journal.Number <= 0) return "El número de planilla es inválido.";
        if (journal.Lines.Count == 0) return "El asiento no contiene líneas.";
        if (journal.Lines.Any(x => string.IsNullOrWhiteSpace(x.AccountCode)))
            return "El asiento contiene cuentas contables vacías.";
        if (journal.Lines.Any(x => x.Debit < 0 || x.Credit < 0 || (x.Debit > 0 && x.Credit > 0)))
            return "Cada línea debe tener un débito o un crédito no negativo.";
        var debit = journal.Lines.Sum(x => x.Debit);
        var credit = journal.Lines.Sum(x => x.Credit);
        return debit > 0 && debit == credit ? null : "El asiento no está balanceado.";
    }
}
