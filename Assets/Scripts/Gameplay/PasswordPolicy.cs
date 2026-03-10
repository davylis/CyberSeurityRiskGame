
using System.Text.RegularExpressions;

public class PasswordPolicy
{
    public static bool HasUppercase(string password)
    {
        return Regex.IsMatch(password, "[A-Z]");
    }

    public static bool HasLowercase(string password)
    {
        return Regex.IsMatch(password, "[a-z]");
    }

    public static bool HasDigit(string password)
    {
        return Regex.IsMatch(password, "[0-9]");
    }

    public static bool HasSymbol(string password)
    {
        return Regex.IsMatch(password, "[^a-zA-Z0-9]");
    }

    public static bool HasMinLength(string password)
    {
        return password.Length >= 8;
    }
    public static bool HasRepetition(string password)
{
    return Regex.IsMatch(password, @"(.)\1{2,}");
}
}