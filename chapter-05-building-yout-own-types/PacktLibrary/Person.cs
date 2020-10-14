using System;
using System.Collections.Generic;
using Packt.Shared;

namespace PacktLibrary
{
    public partial class Person : object
    {
        public string Name;
        public DateTime Nascimento;
        public LugaresFavoritos Lugar;
        public List<Person> Filhos = new List<Person>();

        public void PassingParameters(
            int x,
            ref int y,
            out int z
        )
        {
            z = 99;

            x++;
            y++;
            z++;
        }
    }

    public class BankAccount
    {
        public string AccountName;
        public decimal Balance;
        public static decimal InterestRate;
    }
}