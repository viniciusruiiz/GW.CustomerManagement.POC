using GW.CustomerManagement.Domain.Entities;
using GW.CustomerManagement.Domain.ValueObjects;

namespace GW.CustomerManagement.Domain.Interfaces.Services;

public interface ICustomerService : IService
{
    Task<Customer?> Get(Guid id);
    IEnumerable<Customer> GetAll(int pageSize, int pageNumber);
    Task<Customer> Create(Customer customer);
    Task<Customer> UpdateName(Guid id, Name newName);
    Task<Customer> UpdateAddress(Guid id, Address newAddress);
    Task<Customer> Delete(Guid id);
}
