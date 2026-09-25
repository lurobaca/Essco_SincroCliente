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
    [TempData] public bool? OperationSucceeded { get; set; }
    public string? EditingExperienceKey { get; private set; }
    public string SelectedSection { get; private set; } = "experience";

    /// <summary>Carga la formación y selecciona una experiencia para editar cuando se solicita.</summary>
    public async Task<IActionResult> OnGetAsync(string id, string? experience, string? section, CancellationToken t)
    {
        if (!await Load(id, t)) return NotFound();

        // Conservar la pestaña elegida desde el expediente sin aceptar nombres arbitrarios.
        SelectedSection = section == "education" ? "education" : "experience";

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
    /// <summary>Registra un estudio y conserva visible la pestaña Educación.</summary>
    public async Task<IActionResult> OnPostEducationAsync(string id, bool returnToDetail, CancellationToken cancellationToken)
    {
        var input = EducationInput;
        var education = new EmployeeEducation(
            input.Institution ?? "",
            input.Title ?? "",
            input.From,
            input.To,
            input.InProgress,
            input.Degree ?? "");

        var wasSaved = await service.AddEducationAsync(id, education, cancellationToken);
        return Done(id, wasSaved, "Estudio registrado.", "education", returnToDetail);
    }
    /// <summary>Registra una experiencia y vuelve a la pestaña desde donde se envió.</summary>
    public async Task<IActionResult> OnPostExperienceAsync(
        string id,
        bool returnToDetail,
        CancellationToken cancellationToken)
    {
        var input = ExperienceInput;
        var experience = new EmployeeExperience(
            input.CompanyId ?? "",
            input.Company ?? "",
            input.Position ?? "",
            input.From,
            input.To,
            input.Reference ?? "",
            input.Phone ?? "",
            input.Comments ?? "");

        var wasSaved = await service.AddExperienceAsync(id, experience, cancellationToken);
        return Done(id, wasSaved, "Experiencia registrada.", returnToDetail: returnToDetail);
    }
    /// <summary>Guarda los cambios de una experiencia previamente seleccionada.</summary>
    public async Task<IActionResult> OnPostUpdateExperienceAsync(string id, string key, bool returnToDetail, CancellationToken t)
    {
        // Comprobar que el empleado existe antes de modificar su experiencia laboral.
        if (await employees.GetAsync(id, t) is null) return NotFound();

        var input = ExperienceInput;
        var item = new EmployeeExperience(input.CompanyId ?? "", input.Company ?? "", input.Position ?? "",
            input.From, input.To, input.Reference ?? "", input.Phone ?? "", input.Comments ?? "");
        var updated = await service.UpdateExperienceAsync(id, key, item, t);
        return Done(id, updated, "Experiencia actualizada.", returnToDetail: returnToDetail);
    }
    /// <summary>Elimina un estudio y conserva visible la pestaña Educación.</summary>
    public async Task<IActionResult> OnPostDeleteEducationAsync(string id, string key, bool returnToDetail, CancellationToken cancellationToken)
    {
        var wasDeleted = await service.DeleteEducationAsync(id, key, cancellationToken);
        return Done(id, wasDeleted, "Estudio eliminado.", "education", returnToDetail);
    }

    /// <summary>Elimina una experiencia laboral existente.</summary>
    public async Task<IActionResult> OnPostDeleteExperienceAsync(string id, string key, bool returnToDetail, CancellationToken cancellationToken)
    {
        var wasDeleted = await service.DeleteExperienceAsync(id, key, cancellationToken);
        return Done(id, wasDeleted, "Experiencia eliminada.", returnToDetail: returnToDetail);
    }

    /// <summary>Publica el resultado y vuelve a la pestaña donde se ejecutó la operación.</summary>
    private IActionResult Done(string id, bool succeeded, string message, string section = "experience", bool returnToDetail = false)
    {
        StatusMessage = succeeded ? message : "Revise los datos; no fue posible completar la operación.";
        if (returnToDetail)
        {
            OperationSucceeded = succeeded;
        }
        return returnToDetail
            ? RedirectToPage(
                "Detail",
                pageHandler: null,
                routeValues: new { id, section },
                fragment: section == "education" ? "education-pane" : "experience-pane")
            : RedirectToPage(new { id, section });
    }
    private async Task<bool> Load(string id, CancellationToken t) { var e = await employees.GetAsync(id, t); if (e is null) return false; EmployeeName = e.Employee.Name; Education = await service.ListEducationAsync(id, t); Experience = await service.ListExperienceAsync(id, t); return true; }
    public sealed class EducationForm { public string? Institution { get; set; } public string? Title { get; set; } public DateOnly From { get; set; } public DateOnly To { get; set; } public bool InProgress { get; set; } public string? Degree { get; set; } }
    public sealed class ExperienceForm { public string? CompanyId { get; set; } public string? Company { get; set; } public string? Position { get; set; } public DateOnly From { get; set; } public DateOnly To { get; set; } public string? Reference { get; set; } public string? Phone { get; set; } public string? Comments { get; set; } }
}
