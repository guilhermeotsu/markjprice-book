using System;
using Packt.Shared;
using PacktLibrary;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bob = new Person();
            bob.Name = "Dale doly";
            bob.Nascimento = new DateTime(1998, 08, 10);
            bob.Lugar = LugaresFavoritos.Bar | LugaresFavoritos.Restaurante;
            bob.Filhos.Add(new Person { Name = "bob filho" });

            WriteLine($"Bob: Nome: {bob.Name} nascimento: {bob.Nascimento} Lugar: {bob.Lugar}");

            var alice = new Person();
            alice.Name = "Alice";
            alice.Nascimento = new DateTime(1989, 03, 19);
            alice.Lugar = LugaresFavoritos.Bar;

            WriteLine($"Nome: {alice.Name} Nasc: {alice.Nascimento} Lugare: {alice.Lugar}");

            BankAccount.InterestRate = 0.012M;
            var bc = new BankAccount();
            bc.AccountName = "Bora dale!";
            bc.Balance = 1200M;

            WriteLine($"{bc.Balance * BankAccount.InterestRate:C} interest");
            WriteLine($"{2:hh:mm:ss} on a {2:dddd}");


            (string, int) fruit = GetFruit();

            WriteLine($"{fruit.Item1} has {fruit.Item2}");


            var fruitNamed = GetFruit1();

            WriteLine($"Fruit named: {fruitNamed.Name} has {fruitNamed.Amount}");

            WriteLine("TUPLAS");

            var thing1 = ("Nevile", 1);

            WriteLine($"{thing1.Item1} has {thing1.Item2} filhos");

            var thing2 = (bob.Name, Filhos: bob.Filhos.Count, Now: DateTime.Now);

            WriteLine($"{thing2.Name} has {thing2.Filhos} now {thing2.Now}");

            // DESCONTRUÇAO DE TUPLAS
            (string name, int amount) = GetFruit();
            WriteLine($"Name {name}, Amount: {amount}");

            (double, int) t =  (4.5, 3);
            WriteLine(t.ToString());
            WriteLine($"hash de {t} é {t.GetHashCode()}");

            WriteLine();
            WriteLine();
            WriteLine("Passagem de parametros");

            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Antes: a = {a}\nb = {b}\nc = {c}");
            bob.PassingParameters(a, ref b, out c);
            WriteLine($"Depois: a = {a}\nb = {b}\nc = {c}");
            
            WriteLine();

            int d = 10;
            int e = 20;
            WriteLine($"Antes: d = {d}\ne = {e}\f = nao existe");

            // simplificaçao do parametro out
            bob.PassingParameters(d, ref e, out int f);
            WriteLine($"Defapois: d = {d}\ne = {e}\f = {f}");

            WriteLine();

            var gui = new Person();
            gui.Name = "Guilherme";
            gui.Nascimento = new DateTime(year: 1998, month: 09, day: 19);
            gui.ComidaFavorita = "pizza";
            
            WriteLine($"Person Gui: {gui.Name}, {gui.Age}, {gui.ComidaFavorita}");
            gui.Filhos.Add(new Person { Name = "Filho1"});
            gui.Filhos.Add(new Person { Name = "Filho2"});

            WriteLine($"Filho 1 de Gui: {gui.Filhos[0].Name}");
            WriteLine($"Filho 2 de Gui: {gui.Filhos[1].Name}");

        }

        // Exemplo de utilziação de Tuplas
        static (string, int) GetFruit()
        {
            return ("Apple", 5);
        }

        static (string Name, int Amount) GetFruit1()
        {
            return (Name: "Orange", Amount: 10);
        }
    }
}
