namespace Essco.Application.HumanResources;

public sealed record EmployeeEducation(string Institution, string Title, DateOnly From, DateOnly To, bool InProgress, string Degree);
public sealed record EmployeeExperience(string CompanyId, string Company, string Position, DateOnly From, DateOnly To, string Reference, string Phone, string Comments);
public interface IEmployeeBackgroundRepository
{
    ValueTask<IReadOnlyCollection<EmployeeEducation>> ListEducationAsync(string employeeId, CancellationToken cancellationToken);
    ValueTask<IReadOnlyCollection<EmployeeExperience>> ListExperienceAsync(string employeeId, CancellationToken cancellationToken);
    ValueTask<bool> AddEducationAsync(string employeeId, EmployeeEducation item, CancellationToken cancellationToken);
    ValueTask<bool> AddExperienceAsync(string employeeId, EmployeeExperience item, CancellationToken cancellationToken);
    ValueTask<bool> DeleteEducationAsync(string employeeId, string institution, CancellationToken cancellationToken);
    ValueTask<bool> DeleteExperienceAsync(string employeeId, string companyId, CancellationToken cancellationToken);
}
public sealed class EmployeeBackgroundService(IEmployeeBackgroundRepository repository)
{
    public ValueTask<IReadOnlyCollection<EmployeeEducation>> ListEducationAsync(string id, CancellationToken t) => repository.ListEducationAsync(id, t);
    public ValueTask<IReadOnlyCollection<EmployeeExperience>> ListExperienceAsync(string id, CancellationToken t) => repository.ListExperienceAsync(id, t);
    public ValueTask<bool> DeleteEducationAsync(string id, string institution, CancellationToken t) => repository.DeleteEducationAsync(id, institution, t);
    public ValueTask<bool> DeleteExperienceAsync(string id, string companyId, CancellationToken t) => repository.DeleteExperienceAsync(id, companyId, t);
    public ValueTask<bool> AddEducationAsync(string id, EmployeeEducation x, CancellationToken t) =>
        string.IsNullOrWhiteSpace(x.Institution) || string.IsNullOrWhiteSpace(x.Title) || x.From > x.To
            ? ValueTask.FromResult(false) : repository.AddEducationAsync(id, x, t);
    public ValueTask<bool> AddExperienceAsync(string id, EmployeeExperience x, CancellationToken t) =>
        string.IsNullOrWhiteSpace(x.CompanyId) || string.IsNullOrWhiteSpace(x.Company) || string.IsNullOrWhiteSpace(x.Position) || x.From > x.To
            ? ValueTask.FromResult(false) : repository.AddExperienceAsync(id, x, t);
}
