using GW.CustomerManagement.Application.ViewModels;

namespace GW.CustomerManagement.Application.Interfaces;

public interface ICustomerAppService : IAppService
{
    Task<CustomerViewModel?> Get(Guid id);
    IEnumerable<CustomerViewModel>? GetAll(PaginationFilterViewModel pageFilter);
    Task<CustomerViewModel> Create(CreateCustomerViewModel newCustomer);
    Task UpdateName(Guid id, UpdateNameViewModel newName);
    Task UpdateAddress(Guid id, AddressViewModel newAddress);
    Task Delete(Guid id);
}
