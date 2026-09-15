using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essco.Web.Pages.Account;

[Authorize]
public sealed class AccessDeniedModel : PageModel;
