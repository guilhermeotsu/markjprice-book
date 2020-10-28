using System;
using static System.Console;

namespace PacktLibrary
{
    public class Employee : Person
    {
        // Extendendo a classe Employee
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }

        // Substituindo métodos
        public new void WriteToConsole()
        {
            WriteLine($"{Name} was born on {Aniversario.ToString("dd/MM/yy")} and hired on {HireDate.ToString("dd/MM/yy")}");
        }

        public override string ToString()
        {
            return $"{Name}'s code is {EmployeeCode}";
        }
    }
}