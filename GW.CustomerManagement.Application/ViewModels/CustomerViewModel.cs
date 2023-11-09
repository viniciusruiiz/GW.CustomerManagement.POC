namespace GW.CustomerManagement.Application.ViewModels;

public class CustomerViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string RG { get; set; } = string.Empty;
    public AddressViewModel Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    public CustomerViewModel()
    {

    }

    public CustomerViewModel(Guid id, string firstName, string lastName, string cpf, string rg,
        string street, string city, string state, string number, string postalCode,
        DateTime createdAt, bool isActive)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        CPF = cpf;
        RG = rg;
        Address = new AddressViewModel(street, city, state, number, postalCode);
        CreatedAt = createdAt;
        IsActive = isActive;
    }
}
