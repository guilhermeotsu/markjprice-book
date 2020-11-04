using System;
using System.Globalization;
using static System.Console;

namespace Internationalization
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo globalization = CultureInfo.CurrentCulture;
            CultureInfo localization = CultureInfo.CurrentUICulture;
            WriteLine($"The current globalization culture is {globalization.Name}:{globalization.DisplayName}");
            WriteLine($"The current localization culture is {localization.Name}:{localization.DisplayName}");
            
            WriteLine();
            WriteLine("en-US: English");
            WriteLine("da-DK: Danishh");
            WriteLine("fr-CA: French");
            
            Write("Enter an ISO culture Code: ");
            string newCulture = ReadLine();
            if(!string.IsNullOrEmpty(newCulture))
            {
                var ci = new CultureInfo(newCulture);
                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ci;
            }
            
            Write("Enter your name: ");
            string name = ReadLine();

            Write("Enter you date of birth: ");
            string dob = ReadLine();

            Write("Enter you salary: ");
            string salary = ReadLine();

            DateTime date = DateTime.Parse(dob);
            int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
            decimal earns = decimal.Parse(salary);
            
            WriteLine($"{name} was born on {date:dddd}, is {minutes:N0} minutes old, and earsn {earns:C}");

        }
    }
}
