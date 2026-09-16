using Essco.Application.HumanResources;
using Essco.Application.Security;
using Essco.Domain.HumanResources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essco.Web.Pages.Employees;

[Authorize(Policy = Permissions.Payroll)]
public sealed class MovementsModel(EmployeeService employees, EmployeeMovementService movements) : PageModel
{
    public EmployeeFile File { get; private set; } = null!;
    [BindProperty] public VacationForm Vacation { get; set; } = new();
    [BindProperty] public DisabilityForm Disability { get; set; } = new();
    [BindProperty] public DeductionForm Deduction { get; set; } = new();
    [BindProperty] public LoanForm Loan { get; set; } = new();
    [TempData] public string? StatusMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(string id, CancellationToken cancellationToken)
    {
        if (!await LoadAsync(id, cancellationToken)) return NotFound();
        var today = DateOnly.FromDateTime(DateTime.Today);
        Vacation = new() { From = today, To = today, Days = 1 };
        Disability = new() { From = today, To = today, Days = 1 };
        Deduction = new() { Date = today, FirstPercentage = 50, SecondPercentage = 50 };
        Loan = new() { Date = today };
        return Page();
    }

    public async Task<IActionResult> OnPostVacationAsync(string id, CancellationToken cancellationToken)
    {
        var result = await movements.SaveVacationAsync(new(id, Vacation.From, Vacation.To, Vacation.Days, Vacation.Comments ?? ""), cancellationToken);
        return Complete(id, result.Succeeded ? $"Vacación {result.Number} registrada." : result.Error);
    }

    public async Task<IActionResult> OnPostDisabilityAsync(string id, CancellationToken cancellationToken)
    {
        var result = await movements.SaveDisabilityAsync(new(id, Disability.From, Disability.To, Disability.Days, Disability.Voucher ?? "", Disability.Detail ?? "", Disability.Type ?? ""), cancellationToken);
        return Complete(id, result.Succeeded ? $"Incapacidad {result.Number} registrada." : result.Error);
    }

    public async Task<IActionResult> OnPostDeductionAsync(string id, CancellationToken cancellationToken)
    {
        var result = await movements.SaveDeductionAsync(new(id, Deduction.Category ?? "", Deduction.Amount, Deduction.Detail ?? "", Deduction.Date, Deduction.FirstPercentage, Deduction.SecondPercentage), cancellationToken);
        return Complete(id, result.Succeeded ? $"Deducción {result.Number} registrada." : result.Error);
    }

    public async Task<IActionResult> OnPostLoanAsync(string id, CancellationToken cancellationToken)
    {
        var employee = await employees.GetAsync(id, cancellationToken);
        if (employee is null) return NotFound();
        var result = await movements.SaveLoanAsync(new(id, employee.Employee.Name, Loan.Date, Loan.Amount, Loan.Type ?? "", Loan.Detail ?? "", Loan.FortnightPayment), cancellationToken);
        return Complete(id, result.Succeeded ? $"Vale/préstamo {result.Number} registrado." : result.Error);
    }

    public async Task<IActionResult> OnPostAnnulAsync(string id, string type, int number, CancellationToken cancellationToken)
    {
        var succeeded = number > 0 && await movements.AnnulAsync(type, number, cancellationToken);
        return Complete(id, succeeded ? $"Movimiento {number} anulado." : "No fue posible anular el movimiento.");
    }

    private IActionResult Complete(string id, string? message)
    {
        StatusMessage = message ?? "No fue posible completar la operación.";
        return RedirectToPage(new { id });
    }

    private async Task<bool> LoadAsync(string id, CancellationToken cancellationToken)
    {
        var file = await employees.GetAsync(id, cancellationToken);
        if (file is null) return false;
        File = file;
        return true;
    }

    public sealed class VacationForm { public DateOnly From { get; set; } public DateOnly To { get; set; } public decimal Days { get; set; } public string? Comments { get; set; } }
    public sealed class DisabilityForm { public DateOnly From { get; set; } public DateOnly To { get; set; } public decimal Days { get; set; } public string? Voucher { get; set; } public string? Detail { get; set; } public string? Type { get; set; } }
    public sealed class DeductionForm { public string? Category { get; set; } public decimal Amount { get; set; } public string? Detail { get; set; } public DateOnly Date { get; set; } public int FirstPercentage { get; set; } public int SecondPercentage { get; set; } }
    public sealed class LoanForm { public DateOnly Date { get; set; } public decimal Amount { get; set; } public string? Type { get; set; } public string? Detail { get; set; } public decimal FortnightPayment { get; set; } }
}
