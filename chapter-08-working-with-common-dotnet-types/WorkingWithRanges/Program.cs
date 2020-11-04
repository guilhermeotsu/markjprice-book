using System;
using static System.Console;

namespace WorkingWithRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Samantha Jones";
            int lengthOfFirst = name.IndexOf(' ');
            int lengthOfLast = name.Length - name.IndexOf(' ') - 1;
            string firstName = name.Substring(0, lengthOfFirst);
            string lastName = name.Substring(name.Length - lengthOfLast, lengthOfLast);
            WriteLine($"First name: {firstName}, Last Name: {lastName}");

            
            ReadOnlySpan<char> nameAsSpan = name.AsSpan();
            var firstNameSpan = nameAsSpan[0..lengthOfFirst];
            var lastNameSpan = nameAsSpan[^lengthOfLast..^0];
            WriteLine($"First Name: {firstNameSpan.ToString()}, Last Name: {lastNameSpan.ToString()}");
        }
    }
}
