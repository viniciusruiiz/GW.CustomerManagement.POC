using GW.CustomerManagement.Data.Configuration;
using GW.CustomerManagement.Domain.Entities;
using GW.CustomerManagement.Domain.Interfaces.Repositories;
using GW.CustomerManagement.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GW.CustomerManagement.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Customer> Create(Customer customer)
    {
        await _context.Customers.AddAsync(customer);

        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task Delete(Customer customer)
    {
         _context.Customers.Remove(customer);

        await _context.SaveChangesAsync();
    }

    public IEnumerable<Customer> SearchByDocuments(string cpf, string rg)
    {
        return _context.Customers.Where(customer => 
            customer.CPF.Value == cpf || 
            customer.RG == rg);
    }

    public async Task<Customer?> Get(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public IEnumerable<Customer> GetAll(int pageSize, int pageNumber)
    {
        return _context.Customers
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
    }

    public async Task<Customer> Update(Customer customerUpdated)
    {
        _context.Customers.Update(customerUpdated);

        await _context.SaveChangesAsync();

        return customerUpdated;
    }
}
