using GW.CustomerManagement.Domain.Entities;
using GW.CustomerManagement.Domain.Exceptions;
using GW.CustomerManagement.Domain.Interfaces.Repositories;
using GW.CustomerManagement.Domain.Interfaces.Services;
using GW.CustomerManagement.Domain.ValueObjects;

namespace GW.CustomerManagement.Service.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<Customer> Create(Customer customer)
    {
        if(_customerRepository.SearchByDocuments(customer.CPF.Value, customer.RG).Any())
            throw new CustomerManagementException("Já existe um usuário cadastrado com os mesmos documentos.");

        return _customerRepository.Create(customer);
    }

    public async Task<Customer> Delete(Guid id)
    {
        var customer = await _customerRepository.Get(id) 
            ?? throw new CustomerManagementException("Usuário Inexistente");

        await _customerRepository.Delete(customer);

        return customer;
    }

    public async Task<Customer?> Get(Guid id)
    {
        return await _customerRepository.Get(id);
    }

    public IEnumerable<Customer> GetAll(int pageSize, int pageNumber)
    {
        return _customerRepository.GetAll(pageSize, pageNumber);
    }

    public async Task<Customer> UpdateAddress(Guid id, Address newAddress)
    {
        var customer = await _customerRepository.Get(id)
            ?? throw new CustomerManagementException("Usuário Inexistente");

        customer.SetAddress(newAddress);
        await _customerRepository.Update(customer);

        return customer;
    }

    public async Task<Customer> UpdateName(Guid id, Name newName)
    {
        var customer = await _customerRepository.Get(id)
            ?? throw new CustomerManagementException("Usuário Inexistente");

        customer.SetName(newName);
        await _customerRepository.Update(customer);

        return customer;
    }
}
