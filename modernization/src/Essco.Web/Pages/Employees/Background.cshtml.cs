using Essco.Application.HumanResources;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Web.Pages.Employees;

[Authorize(Policy = Permissions.Payroll)]
public sealed class BackgroundModel(EmployeeService employees, EmployeeBackgroundService service) : PageModel
{
    public string EmployeeName { get; private set; } = ""; public IReadOnlyCollection<EmployeeEducation> Education { get; private set; } = []; public IReadOnlyCollection<EmployeeExperience> Experience { get; private set; } = []; [BindProperty] public EducationForm EducationInput { get; set; } = new(); [BindProperty] public ExperienceForm ExperienceInput { get; set; } = new(); [TempData] public string? StatusMessage { get; set; }
    public string? EditingExperienceKey { get; private set; }

    /// <summary>Carga la formación y selecciona una experiencia para editar cuando se solicita.</summary>
    public async Task<IActionResult> OnGetAsync(string id, string? experience, CancellationToken t)
    {
        if (!await Load(id, t)) return NotFound();

        var today = DateOnly.FromDateTime(DateTime.Today);
        EducationInput = new() { From = today, To = today };
        ExperienceInput = new() { From = today, To = today };

        // Solo presentar la edición cuando la clave identifica una fila inequívoca del empleado.
        if (!string.IsNullOrWhiteSpace(experience))
        {
            var matches = Experience.Where(item => item.CompanyId == experience).Take(2).ToArray();
            if (matches.Length != 1) return NotFound();

            var selected = matches[0];
            EditingExperienceKey = selected.CompanyId;
            ExperienceInput = new ExperienceForm
            {
                CompanyId = selected.CompanyId,
                Company = selected.Company,
                Position = selected.Position,
                From = selected.From,
                To = selected.To,
                Reference = selected.Reference,
                Phone = selected.Phone,
                Comments = selected.Comments
            };
        }

        return Page();
    }
    public async Task<IActionResult> OnPostEducationAsync(string id, CancellationToken t) { var x = EducationInput; var ok = await service.AddEducationAsync(id, new(x.Institution ?? "", x.Title ?? "", x.From, x.To, x.InProgress, x.Degree ?? ""), t); return Done(id, ok, "Estudio registrado."); }
    public async Task<IActionResult> OnPostExperienceAsync(string id, CancellationToken t) { var x = ExperienceInput; var ok = await service.AddExperienceAsync(id, new(x.CompanyId ?? "", x.Company ?? "", x.Position ?? "", x.From, x.To, x.Reference ?? "", x.Phone ?? "", x.Comments ?? ""), t); return Done(id, ok, "Experiencia registrada."); }
    /// <summary>Guarda los cambios de una experiencia previamente seleccionada.</summary>
    public async Task<IActionResult> OnPostUpdateExperienceAsync(string id, string key, CancellationToken t)
    {
        // Comprobar que el empleado existe antes de modificar su experiencia laboral.
        if (await employees.GetAsync(id, t) is null) return NotFound();

        var input = ExperienceInput;
        var item = new EmployeeExperience(input.CompanyId ?? "", input.Company ?? "", input.Position ?? "",
            input.From, input.To, input.Reference ?? "", input.Phone ?? "", input.Comments ?? "");
        var updated = await service.UpdateExperienceAsync(id, key, item, t);
        return Done(id, updated, "Experiencia actualizada.");
    }
    public async Task<IActionResult> OnPostDeleteEducationAsync(string id, string key, CancellationToken t) => Done(id, await service.DeleteEducationAsync(id, key, t), "Estudio eliminado."); public async Task<IActionResult> OnPostDeleteExperienceAsync(string id, string key, CancellationToken t) => Done(id, await service.DeleteExperienceAsync(id, key, t), "Experiencia eliminada.");
    private IActionResult Done(string id, bool ok, string message) { StatusMessage = ok ? message : "Revise los datos; no fue posible completar la operación."; return RedirectToPage(new { id }); }
    private async Task<bool> Load(string id, CancellationToken t) { var e = await employees.GetAsync(id, t); if (e is null) return false; EmployeeName = e.Employee.Name; Education = await service.ListEducationAsync(id, t); Experience = await service.ListExperienceAsync(id, t); return true; }
    public sealed class EducationForm { public string? Institution { get; set; } public string? Title { get; set; } public DateOnly From { get; set; } public DateOnly To { get; set; } public bool InProgress { get; set; } public string? Degree { get; set; } }
    public sealed class ExperienceForm { public string? CompanyId { get; set; } public string? Company { get; set; } public string? Position { get; set; } public DateOnly From { get; set; } public DateOnly To { get; set; } public string? Reference { get; set; } public string? Phone { get; set; } public string? Comments { get; set; } }
}
