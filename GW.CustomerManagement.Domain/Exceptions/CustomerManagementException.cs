namespace GW.CustomerManagement.Domain.Exceptions;

public class CustomerManagementException : Exception
{
    public CustomerManagementException() : base() { }
    public CustomerManagementException(string message) : base(message) { }
}
