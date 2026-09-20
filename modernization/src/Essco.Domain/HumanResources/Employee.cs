namespace Essco.Domain.HumanResources;
public sealed record Employee(int Id,string Identification,string Code,string Name,string Position,decimal Salary,DateOnly HireDate,int StatusCode,string Route,string Email,string Phone1,string Phone2,string BankAccount,string CollaboratorId,string LedgerAccount,string Category,decimal VacationEarned,decimal VacationUsed,decimal VacationPending,int TenureYears,int TenureMonths,int TenureDays)
{
 public bool Active=>StatusCode==0;
 public string StatusName=>StatusCode switch{0=>"Activo",1=>"Inactivo",2=>"Cerrado",3=>"Liquidado",_=>$"Estado {StatusCode}"};
 public bool CanEdit=>StatusCode==0;
 public bool CanInactivate=>StatusCode==0;
}
public sealed record EmployeeVacation(int Number,DateOnly From,DateOnly To,decimal Days,string Comments,bool Annulled);
public sealed record EmployeeDisability(int Number,DateOnly From,DateOnly To,decimal Days,string Voucher,string Detail,string Type,bool Annulled);
public sealed record EmployeeDeduction(int Number,string Category,decimal Amount,string Detail,DateOnly Date,bool Annulled,int FirstFortnightPercentage,int SecondFortnightPercentage);
public sealed record EmployeeLoan(int Number,DateOnly Date,decimal Amount,decimal Balance,string Type,string Detail,bool Annulled,decimal FortnightPayment);
public sealed record EmployeeFile(Employee Employee,IReadOnlyCollection<EmployeeVacation>Vacations,IReadOnlyCollection<EmployeeDisability>Disabilities,IReadOnlyCollection<EmployeeDeduction>Deductions,IReadOnlyCollection<EmployeeLoan>Loans);
