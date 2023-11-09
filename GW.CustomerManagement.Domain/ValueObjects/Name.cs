namespace GW.CustomerManagement.Domain.ValueObjects;

public class Name : IEquatable<Name>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    protected Name() { }

    public Name(string firstName, string lastName)
    {
        if(string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Nome inválido! Nome ou sobrenome vazio");

        FirstName = firstName;
        LastName = lastName;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Name);
    }

    public bool Equals(Name? other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other is null) return false;

        return FirstName == other.FirstName &&
               LastName == other.LastName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName);
    }
}
