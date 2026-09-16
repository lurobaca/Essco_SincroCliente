using Essco.Application.Customers;
using Essco.Application.Security;
using Essco.Domain.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Web.Pages.Customers;
[Authorize(Policy=Permissions.Customers)]
public sealed class AccountStatementModel(AccountStatementService service):PageModel
{
    [BindProperty(SupportsGet=true)]public DateOnly From{get;set;}=DateOnly.FromDateTime(DateTime.Today.AddDays(-30));
    [BindProperty(SupportsGet=true)]public DateOnly To{get;set;}=DateOnly.FromDateTime(DateTime.Today);
    [BindProperty(SupportsGet=true)]public AccountStatementStatus Status{get;set;}=AccountStatementStatus.Pending;
    public IReadOnlyCollection<AccountStatementEntry> Items{get;private set;}=[];
    public decimal Total=>Items.Sum(x=>x.Total);
    public decimal Balance=>Items.Sum(x=>x.Balance);
    public async Task OnGetAsync(CancellationToken token)
    {
        try{Items=await service.GetAsync(From,To,Status,token);}catch(ArgumentException ex){ModelState.AddModelError(string.Empty,ex.Message);}
    }
}
