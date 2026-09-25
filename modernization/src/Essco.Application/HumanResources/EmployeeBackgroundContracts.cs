namespace Essco.Application.HumanResources;

/// <summary>Representa un estudio registrado en el expediente laboral.</summary>
public sealed record EmployeeEducation(string Institution, string Title, DateOnly From, DateOnly To, bool InProgress, string Degree);
/// <summary>Representa una experiencia laboral previa del empleado.</summary>
public sealed record EmployeeExperience(string CompanyId, string Company, string Position, DateOnly From, DateOnly To, string Reference, string Phone, string Comments);
/// <summary>Define la persistencia de educación y experiencia laboral.</summary>
public interface IEmployeeBackgroundRepository
{
    /// <summary>Obtiene los estudios registrados.</summary>
    ValueTask<IReadOnlyCollection<EmployeeEducation>> ListEducationAsync(string employeeId, CancellationToken cancellationToken);
    /// <summary>Obtiene la experiencia laboral registrada.</summary>
    ValueTask<IReadOnlyCollection<EmployeeExperience>> ListExperienceAsync(string employeeId, CancellationToken cancellationToken);
    /// <summary>Agrega un estudio al expediente.</summary>
    ValueTask<bool> AddEducationAsync(string employeeId, EmployeeEducation item, CancellationToken cancellationToken);
    /// <summary>Agrega una experiencia al expediente.</summary>
    ValueTask<bool> AddExperienceAsync(string employeeId, EmployeeExperience item, CancellationToken cancellationToken);
    /// <summary>Actualiza una única experiencia identificada por la cédula de empresa original.</summary>
    ValueTask<bool> UpdateExperienceAsync(string employeeId, string companyId, EmployeeExperience item, CancellationToken cancellationToken);
    /// <summary>Elimina un estudio del expediente.</summary>
    ValueTask<bool> DeleteEducationAsync(string employeeId, string institution, CancellationToken cancellationToken);
    /// <summary>Elimina una experiencia del expediente.</summary>
    ValueTask<bool> DeleteExperienceAsync(string employeeId, string companyId, CancellationToken cancellationToken);
}
/// <summary>Aplica las reglas de mantenimiento de formación y experiencia.</summary>
public sealed class EmployeeBackgroundService(IEmployeeBackgroundRepository repository)
{
    /// <summary>Obtiene la formación del empleado.</summary>
    public ValueTask<IReadOnlyCollection<EmployeeEducation>> ListEducationAsync(string id, CancellationToken t) => repository.ListEducationAsync(id, t);
    /// <summary>Obtiene la experiencia del empleado.</summary>
    public ValueTask<IReadOnlyCollection<EmployeeExperience>> ListExperienceAsync(string id, CancellationToken t) => repository.ListExperienceAsync(id, t);
    /// <summary>Elimina un estudio del empleado.</summary>
    public ValueTask<bool> DeleteEducationAsync(string id, string institution, CancellationToken t) => repository.DeleteEducationAsync(id, institution, t);
    /// <summary>Elimina una experiencia del empleado.</summary>
    public ValueTask<bool> DeleteExperienceAsync(string id, string companyId, CancellationToken t) => repository.DeleteExperienceAsync(id, companyId, t);
    /// <summary>Valida y actualiza una experiencia laboral existente.</summary>
    public ValueTask<bool> UpdateExperienceAsync(string id, string companyId, EmployeeExperience item, CancellationToken t)
    {
        // La cédula de empresa identifica la fila seleccionada y no puede cambiarse en esta operación.
        if (string.IsNullOrWhiteSpace(companyId) || companyId != item.CompanyId || !ValidExperience(item))
        {
            return ValueTask.FromResult(false);
        }

        return repository.UpdateExperienceAsync(id, companyId, item, t);
    }
    /// <summary>Valida y agrega un estudio al expediente.</summary>
    public ValueTask<bool> AddEducationAsync(string id, EmployeeEducation x, CancellationToken t) =>
        string.IsNullOrWhiteSpace(x.Institution) || string.IsNullOrWhiteSpace(x.Title) || x.From > x.To
            ? ValueTask.FromResult(false) : repository.AddEducationAsync(id, x, t);
    /// <summary>Valida y agrega una experiencia al expediente.</summary>
    public ValueTask<bool> AddExperienceAsync(string id, EmployeeExperience x, CancellationToken t) =>
        ValidExperience(x) ? repository.AddExperienceAsync(id, x, t) : ValueTask.FromResult(false);

    /// <summary>Comprueba los datos obligatorios que validaba el formulario original de experiencia.</summary>
    private static bool ValidExperience(EmployeeExperience item)
    {
        // Regla heredada: la empresa, el puesto, la referencia, el teléfono y el comentario son obligatorios.
        return !string.IsNullOrWhiteSpace(item.CompanyId)
            && !string.IsNullOrWhiteSpace(item.Company)
            && !string.IsNullOrWhiteSpace(item.Position)
            && !string.IsNullOrWhiteSpace(item.Reference)
            && !string.IsNullOrWhiteSpace(item.Phone)
            && !string.IsNullOrWhiteSpace(item.Comments)
            && item.From <= item.To;
    }
}
