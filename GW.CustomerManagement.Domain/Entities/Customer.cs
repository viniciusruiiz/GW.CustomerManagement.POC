using GW.CustomerManagement.Domain.Util;
using GW.CustomerManagement.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace GW.CustomerManagement.Domain.Entities;

public class Customer : Entity
{
    public Name Name { get; private set; }
    public string RG { get; private set; }
    public CPF CPF { get; private set; }
    public Address Address { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }

    public Customer(Guid id, string firstName, string lastName, string rg, string cpf,
        string street, string city, string state, string number, string postalCode, 
        DateTime createdAt, bool isActive)
    {
        if (id == Guid.Empty || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(rg) || createdAt == DateTime.MinValue)
            throw new ArgumentException("Argumentos inválidos/faltantes na criaçao de usuário");

        rg = rg.RemoveHyphensAndDots();

        if(!Regex.IsMatch(rg, @"^\d{8}(\d|x|X){1}$"))
            throw new ArgumentException("RG inválido! RG deve ser apenas numérico");

        Id = id;
        Name = new Name(firstName, lastName);
        RG = rg;
        CPF = new CPF(cpf);
        Address = new Address(street, city, state, number, postalCode);
        CreatedAt = createdAt;
        IsActive = isActive;
    }

    protected Customer() { }

    public void SetName(Name name)
    {
        Name = name;
    }

    public void SetAddress(Address address)
    {
        Address = address;
    }
}
