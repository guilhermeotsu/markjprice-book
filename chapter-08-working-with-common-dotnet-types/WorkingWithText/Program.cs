using System;
using static System.Console;

namespace WorkingWithText
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");
            
            string city = "London";
            WriteLine($"{city} tem {city.Length} caracteres");

            var recombine = string.Join("=>", new string[] { "Brazil", "Canada", "EUA" });
            WriteLine(recombine);

            WriteLine();

            string fruit = "Uva";
            decimal price = 0.39M;
            DateTime when = DateTime.Today;
            WriteLine($"{fruit} custa {price} on {when}");
            WriteLine($"{fruit} custa {price:C} on {when:dddd}s");
        }
    }
}
