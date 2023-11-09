using GW.CustomerManagement.Domain.ValueObjects;

namespace GW.CustomerManagement.Domain.Tests.ValueObjectsTests;

public class CPFTests
{
    [Fact]
    public void CreateValidCPF()
    {
        var CPF = new CPF("704.018.730-21");

        Assert.NotNull(CPF);
    }

    [Fact]
    public void CreateCPFWithEmpytField()
    {
        Assert.Throws<ArgumentException>(() => new CPF(""));
    }

    [Fact]
    public void CreateCPFWithInvalidField()
    {
        Assert.Throws<ArgumentException>(() => new CPF("blablabla"));
        Assert.Throws<ArgumentException>(() => new CPF("55555555555"));
        Assert.Throws<ArgumentException>(() => new CPF("58963214578"));
    }
}
