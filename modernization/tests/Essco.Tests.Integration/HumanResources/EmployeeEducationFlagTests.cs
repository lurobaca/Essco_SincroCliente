using System.Data;
using Essco.Infrastructure.Data;

namespace Essco.Tests.Integration.HumanResources;

/// <summary>Protege la lectura del indicador EnCurso almacenado por WinForms.</summary>
public sealed class EmployeeEducationFlagTests
{
    /// <summary>Reconoce las representaciones históricas conocidas sin alterar su sentido.</summary>
    [Theory]
    [InlineData("0", false)]
    [InlineData("1", true)]
    [InlineData("False", false)]
    [InlineData("True", true)]
    [InlineData(0, false)]
    [InlineData(1, true)]
    [InlineData(false, false)]
    [InlineData(true, true)]
    public void Reads_known_legacy_values(object databaseValue, bool expected)
    {
        var isInProgress = SqlServerEmployeeBackgroundRepository.ReadInProgress(databaseValue);

        Assert.Equal(expected, isInProgress);
    }

    /// <summary>Detiene la lectura ante un valor desconocido en lugar de inventar false.</summary>
    [Fact]
    public void Rejects_unknown_legacy_value()
    {
        Assert.Throws<DataException>(() => SqlServerEmployeeBackgroundRepository.ReadInProgress("pendiente"));
    }
}
