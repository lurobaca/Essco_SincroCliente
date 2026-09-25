using Essco.Application.HumanResources;
using Essco.Application.Security;
using Essco.Domain.HumanResources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essco.Web.Pages.Employees;

/// <summary>
/// Presenta el expediente del empleado y sus datos de experiencia y educación.
/// </summary>
[Authorize(Policy = Permissions.EmployeesView)]
public sealed class DetailModel(
    EmployeeService employeeService,
    EmployeeBackgroundService backgroundService,
    IAuthorizationService authorizationService) : PageModel
{
    public new EmployeeFile File { get; private set; } = null!;

    public bool CanManage { get; private set; }

    public bool CanViewBackground { get; private set; }

    public IReadOnlyCollection<EmployeeEducation> Education { get; private set; } = [];

    public IReadOnlyCollection<EmployeeExperience> Experience { get; private set; } = [];

    public EmployeeExperience? SelectedExperience { get; private set; }

    public string SelectedSection { get; private set; } = "overview";

    [BindProperty(SupportsGet = true)]
    public string? Notice { get; set; }

    /// <summary>
    /// Carga el expediente y, si el usuario tiene permiso de planilla, sus antecedentes.
    /// </summary>
    public async Task<IActionResult> OnGetAsync(
        string id,
        string? section,
        string? experience,
        CancellationToken cancellationToken)
    {
        var employeeFile = await employeeService.GetAsync(id, cancellationToken);
        if (employeeFile is null)
        {
            return NotFound();
        }

        File = employeeFile;
        CanManage = (await authorizationService.AuthorizeAsync(User, Permissions.EmployeesManage)).Succeeded;
        CanViewBackground = (await authorizationService.AuthorizeAsync(User, Permissions.Payroll)).Succeeded;
        SelectedSection = section is "experience" or "education" ? section : "overview";

        if (CanViewBackground)
        {
            Education = await backgroundService.ListEducationAsync(id, cancellationToken);
            Experience = await backgroundService.ListExperienceAsync(id, cancellationToken);
        }

        if (!string.IsNullOrWhiteSpace(experience))
        {
            if (!CanViewBackground)
            {
                return Forbid();
            }

            var matches = Experience
                .Where(item => string.Equals(item.CompanyId, experience, StringComparison.Ordinal))
                .Take(2)
                .ToArray();

            if (matches.Length != 1)
            {
                return NotFound();
            }

            SelectedExperience = matches[0];
            SelectedSection = "experience";
        }

        return Page();
    }

    /// <summary>
    /// Devuelve la fotografía validada del empleado para el encabezado del expediente.
    /// </summary>
    public async Task<IActionResult> OnGetPhotoAsync(string id, CancellationToken cancellationToken)
    {
        var photo = await employeeService.GetPhotoAsync(id, cancellationToken);
        var contentType = photo is null ? null : EmployeePhotoValidation.DetectContentType(photo);

        return photo is { Length: > 0 } && contentType is not null
            ? base.File(photo, contentType)
            : NotFound();
    }
}
