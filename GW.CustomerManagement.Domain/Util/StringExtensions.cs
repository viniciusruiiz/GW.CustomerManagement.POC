namespace GW.CustomerManagement.Domain.Util;

public static class StringExtensions
{
    public static string OnlyNumericalCharacters(this string str)
    {
        return new string(str.Where(char.IsDigit).ToArray());
    }

    public static string RemoveHyphensAndDots(this string str)
    {
        return str.Replace("-", "").Replace(".", "").Trim();
    }
}
