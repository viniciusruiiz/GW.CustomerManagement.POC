using System.Text.RegularExpressions;

namespace GW.CustomerManagement.Domain.ValueObjects;

public class Address : IEquatable<Address>
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Number { get; private set; }
    public string PostalCode { get; private set; }

    protected Address() { }

    public Address(string street, string city, string state, string number, string postalCode)
    {
        if(string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(state) ||
            string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentException("Endereço inválido!");

        if (!IsValidNumber(number)) throw new ArgumentException("Numero da residência inválido");
        if(!IsValidPostalCode(postalCode)) throw new ArgumentException("CEP inválido");

        Street = street;
        City = city;
        State = state;
        Number = number;
        PostalCode = postalCode;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Address);
    }

    public bool Equals(Address? other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other is null) return false;

        return Street == other.Street &&
               City == other.City &&
               State == other.State &&
               Number == other.Number &&
               PostalCode == other.PostalCode;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Street, City, State, PostalCode);
    }

    private bool IsValidNumber(string number)
    {
        if (Regex.IsMatch(number, @"^\d+$")) return true;

        return false;
    }

    private bool IsValidPostalCode(string postalCode)
    {
        if (Regex.IsMatch(postalCode, @"^\d{5}-\d{3}$")) return true;

        return false;
    }
}
