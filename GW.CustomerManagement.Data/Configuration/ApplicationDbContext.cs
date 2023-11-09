using GW.CustomerManagement.Data.Mappings;
using GW.CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GW.CustomerManagement.Data.Configuration;

public class ApplicationDbContext : DbContext, IDbContext 
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerMapping());
    }
}
