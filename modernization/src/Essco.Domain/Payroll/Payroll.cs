namespace Essco.Domain.Payroll;

public sealed record PayrollRun(int Number, DateOnly From, DateOnly To, DateTime CreatedAt, string Comments, string CreatedBy, int Status, IReadOnlyCollection<PayrollEmployee> Employees) { public decimal Total => Employees.Sum(x => x.FinalSalary); public bool IsOpen => Status == 0; }
public sealed record PayrollEmployee(string Identification, string Name, string Category, string Position, decimal DaysWorked, decimal MonthlySalary, decimal FinalSalary, decimal SocialSecurity, decimal IncomeTax, decimal OtherDeductions, decimal Loans, decimal Invoices, decimal LiquidationShortage);
public sealed record PayrollFilter(DateOnly? From = null, DateOnly? To = null, string? Comments = null);
