using System;
using static System.Console;
using System.Text.RegularExpressions;

namespace WorkingWithRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Digite sua idade: ");
            string input = ReadLine();

            // @ faz com que caracteres de scape nao funcionem
            var ageChecked = new Regex(@"\d");

            if(ageChecked.IsMatch(input))
            {
                WriteLine("Obrigado!");
                return;
            }

            WriteLine("Esse dado não é valido!");
        }
    }
}
