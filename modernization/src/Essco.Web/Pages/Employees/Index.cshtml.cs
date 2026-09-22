using Essco.Application.HumanResources;
using Essco.Application.Security;
using Essco.Domain.HumanResources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Web.Pages.Employees;

[Authorize(Policy = Permissions.EmployeesView)]
public sealed class IndexModel(EmployeeService service, IAuthorizationService authorization) : PageModel
{ [BindProperty(SupportsGet = true)] public string? Search { get; set; } [BindProperty(SupportsGet = true)] public bool IncludeInactive { get; set; } public IReadOnlyCollection<Employee> Items { get; private set; } = []; public bool CanManage { get; private set; } public async Task OnGetAsync(CancellationToken t) { Items = await service.ListAsync(Search, IncludeInactive, t); CanManage = (await authorization.AuthorizeAsync(User, Permissions.EmployeesManage)).Succeeded; } }
