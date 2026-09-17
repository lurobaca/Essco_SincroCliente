using Essco.Application.HumanResources;
namespace Essco.Tests.Unit.HumanResources;
public sealed class EmployeeAttachmentTests
{
    [Fact]
    public void Rejects_html_disguised_as_image() =>
        Assert.Null(EmployeeAttachment.Extension(System.Text.Encoding.UTF8.GetBytes("<html>test</html>")));
    [Fact]
    public void Rejects_oversized_image()
    {
        var bytes = new byte[EmployeeAttachment.MaximumBytes + 1];
        bytes[0] = 255; bytes[1] = 216; bytes[2] = 255;
        Assert.Null(EmployeeAttachment.Extension(bytes));
    }
    [Theory]
    [InlineData("vacation", true)]
    [InlineData("disability", true)]
    [InlineData("loan", true)]
    [InlineData("Empleado", false)]
    [InlineData("", false)]
    public void Only_supported_targets_are_allowed(string kind, bool expected) =>
        Assert.Equal(expected, EmployeeAttachment.ValidKind(kind));
}
