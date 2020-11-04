using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using static System.Console;

namespace WorkingWithLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("Paris");
            cities.Add("Milao");
            WriteLine("Init list");

            foreach (var item in cities)
                WriteLine(item);
            
            WriteLine($"Primeira cidade: {cities[0]}");
            WriteLine($"Última cidade: {cities[cities.Count - 1]}");

            cities.Insert(0, "Sidney");

            WriteLine("Depois de inserir Sidney no indice 0");
            foreach (var item in cities)
                WriteLine(item);

            cities.RemoveAt(1);
            cities.Remove("Milao");

            WriteLine("depois de remover duas cidade");

            foreach (var item in cities)
                WriteLine(item);


            WriteLine();
            WriteLine("Trabalhando com listas imutaveis");

            var immutableCities = cities.ToImmutableList();
            var newList = immutableCities.Add("Rio");

            WriteLine("Lista imutavel de cidade");
            foreach (var city in immutableCities)
                WriteLine(city);

            WriteLine("new list");
            
            foreach (var city in newList)
                WriteLine(city);
        }
    }
}
