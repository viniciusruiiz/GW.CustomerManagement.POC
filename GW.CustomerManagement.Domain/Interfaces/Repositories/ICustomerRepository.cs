using GW.CustomerManagement.Domain.Entities;
using GW.CustomerManagement.Domain.ValueObjects;

namespace GW.CustomerManagement.Domain.Interfaces.Repositories;

public interface ICustomerRepository : IRepository
{
    Task<Customer?> Get(Guid id);
    IEnumerable<Customer> GetAll(int pageSize, int pageNumber);
    IEnumerable<Customer> SearchByDocuments(string cpf, string rg);
    Task<Customer> Create(Customer customer);
    Task<Customer> Update(Customer customerUpdated);
    Task Delete(Customer customer);
}
