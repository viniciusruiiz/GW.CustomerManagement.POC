using GW.CustomerManagement.Domain.Util;

namespace GW.CustomerManagement.Domain.ValueObjects;

public class CPF : IEquatable<CPF>
{
    public string Value { get; private set; }

    public CPF(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("CPF vazio");

        value = value.OnlyNumericalCharacters();

        if (!IsValidCPF(value)) throw new ArgumentException("CPF inválido");
        
        Value = value;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as CPF);
    }

    public bool Equals(CPF? other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other is null) return false;

        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    private bool IsValidCPF(string cpf)
    {
        if (cpf.Length != 11) return false;

        if (cpf.All(digit => digit == cpf[0])) return false;

        int[] cpfDigits = cpf.Select(digit => digit - '0').ToArray();
        for (int i = 0; i < 2; i++)
        {
            int sum = 0;
            int multiplier = 10 + i;
            for (int j = 0; j < 9 + i; j++)
            {
                sum += cpfDigits[j] * multiplier;
                multiplier--;
            }

            int remainder = sum % 11;
            int validDigit = remainder < 2 ? 0 : 11 - remainder;
            if (cpfDigits[9 + i] != validDigit) return false;
        }

        return true;
    }
}
