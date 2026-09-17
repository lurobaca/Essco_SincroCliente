using Essco.Application.HumanResources;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essco.Web.Pages.Employees;

[Authorize(Policy = Permissions.Payroll)]
[RequestSizeLimit(6 * 1024 * 1024)]
public sealed class AttachmentModel(IEmployeeAttachmentRepository attachments) : PageModel
{
    [BindProperty] public IFormFile? Upload { get; set; }
    public IActionResult OnGet(string id, string kind, int number) =>
        EmployeeAttachment.ValidKind(kind) && number > 0 ? Page() : NotFound();

    public async Task<IActionResult> OnGetDownloadAsync(string id, string kind, int number, CancellationToken token)
    {
        if (!EmployeeAttachment.ValidKind(kind) || number <= 0) return NotFound();
        var bytes = await attachments.GetAsync(id, kind, number, token);
        if (bytes is null) return NotFound();
        Response.Headers["X-Content-Type-Options"] = "nosniff";
        return File(bytes, "application/octet-stream", $"adjunto-{number}{EmployeeAttachment.Extension(bytes) ?? ".bin"}");
    }

    public async Task<IActionResult> OnPostAsync(string id, string kind, int number, CancellationToken token)
    {
        if (!EmployeeAttachment.ValidKind(kind) || number <= 0) return NotFound();
        if (Upload is null || Upload.Length is 0 or > EmployeeAttachment.MaximumBytes)
        {
            ModelState.AddModelError("", "Seleccione una imagen PNG o JPEG de hasta 5 MB.");
            return Page();
        }
        using var buffer = new MemoryStream();
        await Upload.CopyToAsync(buffer, token);
        var content = buffer.ToArray();
        if (EmployeeAttachment.Extension(content) is null)
        {
            ModelState.AddModelError("", "El archivo no tiene una cabecera PNG o JPEG válida.");
            return Page();
        }
        if (!await attachments.SaveAsync(id, kind, number, content, token))
        {
            ModelState.AddModelError("", "El movimiento no existe, está anulado o no se pudo guardar.");
            return Page();
        }
        return RedirectToPage("Detail", new { id });
    }
}
