using System;
using static System.Console;
using PacktLibrary;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var harry = new Person {  };
            var p1 = new Person { Name = "Guilherme" };
            var p2 = new Person { Name = "Guilherme2" };

            var baby = p1 * p2;
            
            WriteLine(baby.Name);

            WriteLine($"5! é {Person.Factorial(5)}");

            // Atribuindo a assinatura do método para o campo delegate
            p1.Shoult += Harry_Shout;
            p1.Poke();
            p1.Poke();
            p1.Poke();
            p1.Poke();

            Person[] peoples = 
            {
                new Person { Name = "Simon" },
                new Person { Name = "Jenny" },
                new Person { Name = "Adam" },
                new Person { Name = "Richard" }
            };

            WriteLine("Init list people");

            foreach (var person in peoples)
                WriteLine(person.Name);

            WriteLine("use Person IComparable");
            
            Array.Sort(peoples);
            
            foreach (var person in peoples)
                WriteLine(person.Name);

            WriteLine("Usando PersonComparer IComparer implementado");

            // Especificando o algoritmo de ordenaçao
            // Ordenando o nome pelos menores nomes,
            // quando tiver o mesmo tamanho ordena pela ordem alfabetica
            Array.Sort(peoples, new PersonComparer());

            foreach (var person in peoples)
                WriteLine(person.Name);

            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with an integer: {t1.Process(42)}");

            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with string: {t2.Process("apple")}");

            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with an integer: {gt1.Process(42)}");

            var gt2 = new GenericThing<string>();
            gt2.Data = "apple";
            WriteLine($"GenericThing with a string {gt2.Process("apple")}");

            WriteLine();

            string number1 = "4";
            WriteLine($"{number1} ao quadrado é {Squarer.Square<string>(number1)}");

            byte number2 = 3;
            WriteLine($"{number2} ao quadrado é {Squarer.Square<byte>(number2)}");

            WriteLine();

            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);

            var dv3 = dv1 + dv2;

            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

            WriteLine();

            // Casting implicito, é possivel armazenar um tipo derivado em um tipo base
            Employee aliceEmployee = new Employee { Name = "Alice", EmployeeCode = "AAA123" };
            Person aliceInPerson = aliceEmployee;
            aliceEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            WriteLine(aliceEmployee.ToString()); // vai chamar o toString da classe de Employee
            WriteLine(aliceInPerson.ToString()); // tambem vai chamar o toString de Employee

            // Casting explicito, dessa forma nao é seguro
            // pode lançar uma exceçao de INvalidaCastException
            //Employee explicitAlice = (Employee)aliceInPerson;

            if(aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee");

                // Casting explicito de maneira segura
                Employee explicitAlice = (Employee)aliceInPerson;
            }
            
            // Outra maneira segura de fazer casting explícito
            // caso nao de para fazer casting nao vai lançar exceçao, vai atribuir nulo
            Employee explicitAlice1 = aliceInPerson as Employee;


            WriteLine("///// Person Exception ///////");
            
            var john = new Person { Name = "Jhon", Aniversario = new DateTime(1998, 07, 19)};

            try {
                john.TimeTravel(new DateTime(1998, 06, 01)); 
                john.TimeTravel(new DateTime(2000, 08, 01));   
            } 
            catch (PersonException ex) 
            {
                WriteLine(ex.Message);    
            }

            WriteLine();
            WriteLine("//// Extension Methods ////");
            string email1 = "gui@teste.com";
            string email2 = "uan&teste.com";

            WriteLine($"{email1} é valido: {email1.IsValidEmail()}");
            WriteLine($"{email2} é valido: {email2.IsValidEmail()}");
        }

        // Manipulando o event Should
        // Microsoft tem uma convensao de nomes para metodos que manipulam eventos:
        // ObjectName_EventName
        // O método só vai ser invocado caso ele seja cutucado (Poke()) no minimo tres vezes
        private static void Harry_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;

            WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
        }
    }
}
