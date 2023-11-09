using Autofac;
using GW.CustomerManagement.Application.AppServices;
using GW.CustomerManagement.Application.Interfaces;
using GW.CustomerManagement.Data.Repositories;
using GW.CustomerManagement.Domain.Interfaces.Repositories;
using GW.CustomerManagement.Domain.Interfaces.Services;
using GW.CustomerManagement.Service.Services;
using System.Reflection;

namespace GW.CustomerManagement.API.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void ConfigureRepositories(this ContainerBuilder builder)
    {
        var dataAssembly = Assembly.GetAssembly(typeof(CustomerRepository));

        builder.RegisterAssemblyTypes(dataAssembly)
            .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IRepository))))
            .AsImplementedInterfaces();
    }

    public static void ConfigureServices(this ContainerBuilder builder)
    {
        var serviceAssembly = Assembly.GetAssembly(typeof(CustomerService));

        builder.RegisterAssemblyTypes(serviceAssembly)
            .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IService))))
            .AsImplementedInterfaces();
    }

    public static void ConfigureAppServices(this ContainerBuilder builder)
    {
        var appServiceAssembly = Assembly.GetAssembly(typeof(CustomerAppService));

        builder.RegisterAssemblyTypes(appServiceAssembly)
            .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IAppService))))
            .AsImplementedInterfaces();
    }
}
