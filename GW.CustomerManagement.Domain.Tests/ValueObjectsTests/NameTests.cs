using GW.CustomerManagement.Domain.ValueObjects;

namespace GW.CustomerManagement.Domain.Tests.ValueObjectsTests;

public class NameTests
{
    [Fact]
    public void CreateValidName()
    {
        var name = new Name("Vinicius", "Ruiz");

        Assert.NotNull(name);
    }

    [Fact]
    public void CreateNameWithEmpytField() 
    {
        Assert.Throws<ArgumentException>(() => new Name("", ""));
        Assert.Throws<ArgumentException>(() => new Name("Vinicius", ""));
        Assert.Throws<ArgumentException>(() => new Name("", "Vinicius"));
    }
}
