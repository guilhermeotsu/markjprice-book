using System.Text.RegularExpressions;

namespace PacktLibrary
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            // validando se o email é valido
            return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}