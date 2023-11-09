namespace GW.CustomerManagement.Application.ViewModels;

public class AddressViewModel
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Number { get; set; }
    public string PostalCode { get; set; }

    public AddressViewModel()
    {
        
    }

    public AddressViewModel(string street, string city, string state, string number, string postalCode)
    {
        Street = street;
        City = city;
        State = state;
        Number = number;
        PostalCode = postalCode;
    }
}
