namespace GW.CustomerManagement.Application.ViewModels;

public class CreateCustomerViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string RG { get; set; } = string.Empty;
    public AddressViewModel Address { get; set; }
}
