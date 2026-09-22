using Essco.Application.HumanResources;
using Essco.Application.Security;
using Essco.Domain.HumanResources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Web.Pages.Employees;

[Authorize(Policy = Permissions.EmployeesView)]
public sealed class DetailModel(EmployeeService service, IAuthorizationService authorization) : PageModel
{ public new EmployeeFile File { get; private set; } = null!; public bool CanManage { get; private set; } [BindProperty(SupportsGet = true)] public string? Notice { get; set; } public async Task<IActionResult> OnGetAsync(string id, CancellationToken t) { var x = await service.GetAsync(id, t); if (x is null) return NotFound(); File = x; CanManage = (await authorization.AuthorizeAsync(User, Permissions.EmployeesManage)).Succeeded; return Page(); } public async Task<IActionResult> OnGetPhotoAsync(string id, CancellationToken t) { var photo = await service.GetPhotoAsync(id, t); var type = photo is null ? null : EmployeePhotoValidation.DetectContentType(photo); return photo is { Length: > 0 } && type is not null ? File(photo, type) : NotFound(); } }
