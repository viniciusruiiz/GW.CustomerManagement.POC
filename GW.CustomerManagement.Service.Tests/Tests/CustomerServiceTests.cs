using GW.CustomerManagement.Domain.Entities;
using GW.CustomerManagement.Domain.Exceptions;
using GW.CustomerManagement.Domain.Interfaces.Repositories;
using GW.CustomerManagement.Domain.ValueObjects;
using GW.CustomerManagement.Service.Services;

namespace GW.CustomerManagement.Service.Tests.Tests;

public class CustomerServiceTests
{
    private readonly Mock<ICustomerRepository> _customerRepositoy;
    private readonly IEnumerable<Customer> _customerList;

    public CustomerServiceTests()
    {
        _customerRepositoy = new Mock<ICustomerRepository>();
        _customerList = new List<Customer>()
        {
            new Customer(Guid.NewGuid(), "Vinicius", "Ruiz", "12345678X", "704.018.730-21",
                "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true)
        };
    }

    [Fact]
    public async Task CreateUserValid()
    {
        // Arrange
        var customerService = new CustomerService(_customerRepositoy.Object);

        var customer = new Customer(Guid.NewGuid(), "Vinicius", "Ruiz", "12345678X", "704.018.730-21",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true);

        _customerRepositoy.Setup(cr => cr.SearchByDocuments(It.IsAny<string>(), It.IsAny<string>())).Returns(new List<Customer>());
        _customerRepositoy.Setup(cr => cr.Create(It.IsAny<Customer>())).ReturnsAsync(customer);

        // Act
        var newCustomer = await customerService.Create(customer);

        // Asset
        Assert.NotNull(newCustomer);
        Assert.True(newCustomer.Id != Guid.Empty);
    }

    [Fact]
    public async Task CreateUserDuplicated()
    {
        // Arrange
        var customerService = new CustomerService(_customerRepositoy.Object);

        var customer = new Customer(Guid.NewGuid(), "Vinicius", "Ruiz", "12345678X", "704.018.730-21",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true);

        _customerRepositoy.Setup(cr => cr.SearchByDocuments(It.IsAny<string>(), It.IsAny<string>())).Returns(_customerList);

        // Act and Assert
        await Assert.ThrowsAsync<CustomerManagementException>(async () =>  await customerService.Create(customer));
    }

    [Fact]
    public async Task DeleteUserValid()
    {
        // Arrange
        var customerService = new CustomerService(_customerRepositoy.Object);

        var userId = Guid.NewGuid();

        var customer = new Customer(userId, "Vinicius", "Ruiz", "12345678X", "704.018.730-21",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true);

        _customerRepositoy.Setup(cr => cr.Get(It.IsAny<Guid>())).ReturnsAsync(customer);

        // Act
        var deletedCustomer = await customerService.Delete(userId);

        //Assert
        Assert.NotNull(deletedCustomer);
    }

    [Fact]
    public async Task DeleteUserNonexistent()
    {
        // Arrange
        var customerService = new CustomerService(_customerRepositoy.Object);

        var userId = Guid.NewGuid();

        var customer = new Customer(Guid.NewGuid(), "Vinicius", "Ruiz", "12345678X", "704.018.730-21",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true);

        _customerRepositoy.Setup(cr => cr.Get(It.IsAny<Guid>())).ReturnsAsync((Customer)null);

        // Act and Assert
        await Assert.ThrowsAsync<CustomerManagementException>(async () => await customerService.Delete(userId));
    }

    [Fact]
    public async Task UpdateNameValid()
    {
        // Arrange
        var customerService = new CustomerService(_customerRepositoy.Object);

        var userId = Guid.NewGuid();
        var newName = new Name("Miguel", "Holanda");

        var customer = new Customer(userId, "Vinicius", "Ruiz", "12345678X", "704.018.730-21",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true);

        _customerRepositoy.Setup(cr => cr.Get(It.IsAny<Guid>())).ReturnsAsync(customer);

        // Act
        var deletedCustomer = await customerService.UpdateName(Guid.NewGuid(), newName);

        //Assert
        Assert.NotNull(deletedCustomer);
    }

    [Fact]
    public async Task UpdateNameNonexistentUser()
    {
        // Arrange
        var customerService = new CustomerService(_customerRepositoy.Object);

        var userId = Guid.NewGuid();
        var newName = new Name("Miguel", "Holanda");

        var customer = new Customer(Guid.NewGuid(), "Vinicius", "Ruiz", "12345678X", "704.018.730-21",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true);

        _customerRepositoy.Setup(cr => cr.Get(It.IsAny<Guid>())).ReturnsAsync((Customer)null);

        // Act and Assert
        await Assert.ThrowsAsync<CustomerManagementException>(async () => await customerService.UpdateName(userId, newName));
    }

    [Fact]
    public async Task UpdateAddressValid()
    {
        // Arrange
        var customerService = new CustomerService(_customerRepositoy.Object);

        var userId = Guid.NewGuid();
        var newAddress = new Address("Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040");

        var customer = new Customer(userId, "Vinicius", "Ruiz", "12345678X", "704.018.730-21",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true);

        _customerRepositoy.Setup(cr => cr.Get(It.IsAny<Guid>())).ReturnsAsync(customer);

        // Act
        var deletedCustomer = await customerService.UpdateAddress(Guid.NewGuid(), newAddress);

        //Assert
        Assert.NotNull(deletedCustomer);
    }

    [Fact]
    public async Task UpdateAddressNonexistentUser()
    {
        // Arrange
        var customerService = new CustomerService(_customerRepositoy.Object);

        var userId = Guid.NewGuid();
        var newAddress = new Address("Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040");

        var customer = new Customer(Guid.NewGuid(), "Vinicius", "Ruiz", "12345678X", "704.018.730-21",
            "Rua Valença do Minho", "São Paulo", "SP", "154", "03583-040", DateTime.UtcNow, true);

        _customerRepositoy.Setup(cr => cr.Get(It.IsAny<Guid>())).ReturnsAsync((Customer)null);

        // Act and Assert
        await Assert.ThrowsAsync<CustomerManagementException>(async () => await customerService.UpdateAddress(userId, newAddress));
    }
}
