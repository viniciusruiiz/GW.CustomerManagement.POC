using GW.CustomerManagement.Application.Interfaces;
using GW.CustomerManagement.Application.ViewModels;
using GW.CustomerManagement.Domain.Entities;
using GW.CustomerManagement.Domain.Interfaces.Services;
using GW.CustomerManagement.Domain.ValueObjects;

namespace GW.CustomerManagement.Application.AppServices;

public class CustomerAppService : ICustomerAppService
{
    private readonly ICustomerService _customerService;

    public CustomerAppService(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<CustomerViewModel> Create(CreateCustomerViewModel newCustomer)
    {
        Customer customer = MapCreateCustomerViewModelToCustomer(newCustomer);

        await _customerService.Create(customer);

        return MapCustomerToCustomerViewModel(customer);
    }

    public async Task Delete(Guid id)
    {
        await _customerService.Delete(id);
    }

    public async Task<CustomerViewModel?> Get(Guid id)
    {
        Customer? customer = await _customerService.Get(id);

        return customer is not null ? MapCustomerToCustomerViewModel(customer) : null;
    }

    public IEnumerable<CustomerViewModel>? GetAll(PaginationFilterViewModel pageFilter)
    {
        IEnumerable<Customer> customers = _customerService.GetAll(pageFilter.PageSize, pageFilter.PageNumber);

        return customers.Any() ?
            customers.Select(c => MapCustomerToCustomerViewModel(c)) :
            null;
    }

    public async Task UpdateAddress(Guid id, AddressViewModel newAddress)
    {
        await _customerService.UpdateAddress(id, MapAddressViewModelToAddress(newAddress));
    }

    public async Task UpdateName(Guid id, UpdateNameViewModel newName)
    {
        await _customerService.UpdateName(id, MapUpdateNameViewModelToName(newName));
    }

    #region Mappings

    private Customer MapCreateCustomerViewModelToCustomer(CreateCustomerViewModel newCustomer)
    {
        return new Customer(
            Guid.NewGuid(),
            newCustomer.FirstName,
            newCustomer.LastName,
            newCustomer.RG,
            newCustomer.CPF,
            newCustomer.Address.Street,
            newCustomer.Address.City,
            newCustomer.Address.State,
            newCustomer.Address.Number,
            newCustomer.Address.PostalCode,
            DateTime.UtcNow,
            true);
    }

    private CustomerViewModel MapCustomerToCustomerViewModel(Customer customer)
    {
        return new CustomerViewModel(
            customer.Id,
            customer.Name.FirstName,
            customer.Name.LastName,
            customer.CPF.Value,
            customer.RG,
            customer.Address.Street,
            customer.Address.City,
            customer.Address.State,
            customer.Address.Number,
            customer.Address.PostalCode,
            customer.CreatedAt,
            customer.IsActive);
    }

    private Address MapAddressViewModelToAddress(AddressViewModel address)
    {
        return new Address(
            address.Street,
            address.City,
            address.State,
            address.Number,
            address.PostalCode);
    }

    private Name MapUpdateNameViewModelToName(UpdateNameViewModel name)
    {
        return new Name(
            name.FirstName,
            name.LastName);
    }

    #endregion
}
