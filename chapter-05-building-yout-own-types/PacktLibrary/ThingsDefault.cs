using System;
using System.Collections.Generic;
using PacktLibrary;

namespace Packt.Shared
{
    public class ThingsDefault
    {
        public int Populacao;
        public DateTime Quando;
        public string Nome;
        public List<Person> Pessoas;
        public ThingsDefault()
        {
            Populacao = default; // c# 7.1 +
            Quando = default;
            Pessoas = default;
        }
    }
}