using GW.CustomerManagement.Domain.ValueObjects;

namespace GW.CustomerManagement.Domain.Tests.ValueObjectsTests;

public class AddressTests
{
    [Fact]
    public void CreateValidAddress()
    {
        var address = new Address("Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040");

        Assert.NotNull(address);
    }

    [Fact]
    public void CreateAddressWithEmpytField()
    {
        Assert.Throws<ArgumentException>(() => new Address("", "São Paulo", "SP", "154", ""));
    }

    [Fact]
    public void CreateAddressWithInvalidField()
    {
        Assert.Throws<ArgumentException>(() => new Address("Rua Valença do Minho", "São Paulo", "SP", "154", "03583040"));
        Assert.Throws<ArgumentException>(() => new Address("Rua Valença do Minho", "São Paulo", "SP", "xxx", "03583-040"));
    }
}
