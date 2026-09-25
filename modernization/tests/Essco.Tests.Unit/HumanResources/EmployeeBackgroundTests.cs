using Essco.Application.HumanResources;

namespace Essco.Tests.Unit.HumanResources;

/// <summary>Comprueba las reglas de formación y experiencia laboral.</summary>
public sealed class EmployeeBackgroundTests
{
    /// <summary>Impide registrar una experiencia sin empresa.</summary>
    [Fact]
    public async Task Rejects_experience_without_company()
    {
        var repository = new RepositoryStub();
        var service = new EmployeeBackgroundService(repository);
        var experience = new EmployeeExperience("", "", "Puesto", new(2020, 1, 1), new(2021, 1, 1), "", "", "");

        Assert.False(await service.AddExperienceAsync("1", experience, default));
        Assert.False(repository.Called);
    }

    /// <summary>Permite registrar estudios válidos.</summary>
    [Fact]
    public async Task Accepts_valid_education()
    {
        var repository = new RepositoryStub();
        var service = new EmployeeBackgroundService(repository);
        var education = new EmployeeEducation("U", "Título", new(2020, 1, 1), new(2021, 1, 1), false, "Bachiller");

        Assert.True(await service.AddEducationAsync("1", education, default));
        Assert.True(repository.Called);
    }

    /// <summary>Rechaza una edición que intente cambiar la clave de la experiencia seleccionada.</summary>
    [Fact]
    public async Task Rejects_experience_update_with_changed_company_id()
    {
        var repository = new RepositoryStub();
        var service = new EmployeeBackgroundService(repository);
        var experience = ValidExperience() with { CompanyId = "otra" };

        Assert.False(await service.UpdateExperienceAsync("1", "original", experience, default));
        Assert.False(repository.Called);
    }

    /// <summary>Rechaza una edición sin los datos obligatorios del formulario original.</summary>
    [Fact]
    public async Task Rejects_experience_update_without_reference()
    {
        var repository = new RepositoryStub();
        var service = new EmployeeBackgroundService(repository);
        var experience = ValidExperience() with { Reference = "" };

        Assert.False(await service.UpdateExperienceAsync("1", "empresa-1", experience, default));
        Assert.False(repository.Called);
    }

    /// <summary>Permite actualizar una experiencia completa con su clave original.</summary>
    [Fact]
    public async Task Accepts_valid_experience_update()
    {
        var repository = new RepositoryStub();
        var service = new EmployeeBackgroundService(repository);

        Assert.True(await service.UpdateExperienceAsync("1", "empresa-1", ValidExperience(), default));
        Assert.True(repository.Called);
    }

    /// <summary>Construye una experiencia completa para las pruebas de actualización.</summary>
    private static EmployeeExperience ValidExperience() =>
        new("empresa-1", "Empresa", "Puesto", new(2020, 1, 1), new(2021, 1, 1), "Referencia", "88888888", "Comentario");

    /// <summary>Registra las llamadas de persistencia sin requerir SQL en las pruebas unitarias.</summary>
    private sealed class RepositoryStub : IEmployeeBackgroundRepository
    {
        public bool Called { get; private set; }

        /// <summary>Devuelve una lista vacía de estudios.</summary>
        public ValueTask<IReadOnlyCollection<EmployeeEducation>> ListEducationAsync(string id, CancellationToken token) =>
            ValueTask.FromResult<IReadOnlyCollection<EmployeeEducation>>([]);

        /// <summary>Devuelve una lista vacía de experiencias.</summary>
        public ValueTask<IReadOnlyCollection<EmployeeExperience>> ListExperienceAsync(string id, CancellationToken token) =>
            ValueTask.FromResult<IReadOnlyCollection<EmployeeExperience>>([]);

        /// <summary>Registra el alta de un estudio.</summary>
        public ValueTask<bool> AddEducationAsync(string id, EmployeeEducation item, CancellationToken token)
        {
            Called = true;
            return ValueTask.FromResult(true);
        }

        /// <summary>Registra el alta de una experiencia.</summary>
        public ValueTask<bool> AddExperienceAsync(string id, EmployeeExperience item, CancellationToken token)
        {
            Called = true;
            return ValueTask.FromResult(true);
        }

        /// <summary>Registra la actualización de una experiencia.</summary>
        public ValueTask<bool> UpdateExperienceAsync(string id, string companyId, EmployeeExperience item, CancellationToken token)
        {
            Called = true;
            return ValueTask.FromResult(true);
        }

        /// <summary>Simula la eliminación de un estudio.</summary>
        public ValueTask<bool> DeleteEducationAsync(string id, string institution, CancellationToken token) => ValueTask.FromResult(true);

        /// <summary>Simula la eliminación de una experiencia.</summary>
        public ValueTask<bool> DeleteExperienceAsync(string id, string companyId, CancellationToken token) => ValueTask.FromResult(true);
    }
}
