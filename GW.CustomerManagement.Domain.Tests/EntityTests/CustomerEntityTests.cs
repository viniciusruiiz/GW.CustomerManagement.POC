using GW.CustomerManagement.Domain.Entities;

namespace GW.CustomerManagement.Domain.Tests.EntityTests;

public class CustomerEntityTests
{
    [Fact]
    public void CreateValidCustomer()
    {
        var customer = new Customer(Guid.NewGuid(), "Vinicius", "Ruiz", "12.345.678-X", "704.018.730-21",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true);

        Assert.NotNull(customer);
    }

    [Fact]
    public void CreateCustomerWithEmpytField()
    {
        Assert.Throws<ArgumentException>(() => new Customer(Guid.Empty, "Vinicius", "Ruiz", "123456789", "70401873021",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true));
    }

    [Fact]
    public void CreateCustomerWithInvalidField()
    {
        Assert.Throws<ArgumentException>(() => new Customer(Guid.NewGuid(), "Vinicius", "Ruiz", "blablabla", "70401873021",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true));
    }
}
