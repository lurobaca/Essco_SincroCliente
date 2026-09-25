using Essco.Application.HumanResources;

namespace Essco.Infrastructure.Data;

/// <summary>
/// Rechaza las operaciones de formación y experiencia cuando no hay una base de datos configurada.
/// </summary>
public sealed class UnavailableEmployeeBackgroundRepository : IEmployeeBackgroundRepository
{
    /// <summary>Construye el error compartido de configuración.</summary>
    private static InvalidOperationException ConfigurationError() =>
        new("Recursos humanos no está configurado.");

    /// <summary>Rechaza la consulta de estudios mientras la base no esté disponible.</summary>
    public ValueTask<IReadOnlyCollection<EmployeeEducation>> ListEducationAsync(string id, CancellationToken cancellationToken) =>
        ValueTask.FromException<IReadOnlyCollection<EmployeeEducation>>(ConfigurationError());

    /// <summary>Rechaza la consulta de experiencias mientras la base no esté disponible.</summary>
    public ValueTask<IReadOnlyCollection<EmployeeExperience>> ListExperienceAsync(string id, CancellationToken cancellationToken) =>
        ValueTask.FromException<IReadOnlyCollection<EmployeeExperience>>(ConfigurationError());

    /// <summary>Rechaza el alta de estudios mientras la base no esté disponible.</summary>
    public ValueTask<bool> AddEducationAsync(string id, EmployeeEducation item, CancellationToken cancellationToken) =>
        ValueTask.FromException<bool>(ConfigurationError());

    /// <summary>Rechaza el alta de experiencias mientras la base no esté disponible.</summary>
    public ValueTask<bool> AddExperienceAsync(string id, EmployeeExperience item, CancellationToken cancellationToken) =>
        ValueTask.FromException<bool>(ConfigurationError());

    /// <summary>Rechaza la edición de experiencias mientras la base no esté disponible.</summary>
    public ValueTask<bool> UpdateExperienceAsync(string id, string companyId, EmployeeExperience item, CancellationToken cancellationToken) =>
        ValueTask.FromException<bool>(ConfigurationError());

    /// <summary>Rechaza la eliminación de estudios mientras la base no esté disponible.</summary>
    public ValueTask<bool> DeleteEducationAsync(string id, string institution, CancellationToken cancellationToken) =>
        ValueTask.FromException<bool>(ConfigurationError());

    /// <summary>Rechaza la eliminación de experiencias mientras la base no esté disponible.</summary>
    public ValueTask<bool> DeleteExperienceAsync(string id, string companyId, CancellationToken cancellationToken) =>
        ValueTask.FromException<bool>(ConfigurationError());
}
