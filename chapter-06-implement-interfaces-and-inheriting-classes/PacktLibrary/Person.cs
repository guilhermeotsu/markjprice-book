using System;
using System.Collections.Generic;
using static System.Console;

namespace PacktLibrary
{
    public class Person : IComparable<Person>
    {
        public string Name;
        public DateTime Aniversario;
        public List<Person> Filhos = new List<Person>();
        public void WriteToConsole()
        {
            WriteLine($"{Name} nascem em {Aniversario:dddd}");
        }
        
        public static Person Procriar(Person p1, Person p2)
        {
            var baby = new Person { Name = $"Bebe de {p1.Name} e {p2.Name}", Aniversario = DateTime.Now };

            // Aqui é adiciona a referência de baby, não seu valor
            // Ou seja se p1 ou p2 Modificar o baby, era reflerir em ambas as instancias
            p1.Filhos.Add(baby);
            p2.Filhos.Add(baby);

            return baby;
        }

        public Person ProcriarCom(Person partner)
        {
            return Procriar(this, partner);
        }

        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procriar(p1, p2);
        }

        // Utilização de Funções Locais
        public static int Factorial(int number)
        {
            if(number < 0)
                throw new ArgumentException($"{nameof(number)} não pode ser menor que 0");
            
            return localFactorial(number);

            // Função local
            int localFactorial(int localNumber) 
            {
                if(localNumber < 1)
                    return 1;
                
                return localNumber * localFactorial(localNumber - 1);
            }
        }
    
        // Sempre que Person for cutucado (Poke())
        // o AgerLevel dele vai ser incrementado
        // Se o nível de AngerLevel for >= 3 
        // O Evento Shoult será lançado
        // mas só se tiver um delegate apontando para o método

        // event faz com que o programador apenas utilize os operadores += ou -=
        // para atribuit ou remover metodos ao delegate
        public event EventHandler Shoult;
        public int AngerLevel;

        public void Poke()
        {
            AngerLevel++;

            if(AngerLevel >= 3) 
            {
                Shoult?.Invoke(this, EventArgs.Empty);
            }
        }

        // Implementando a interface IComparable
        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        // Sobrescrevendo o método toString
        public override string ToString()
        {
            return $"{Name} é um {base.ToString()}";
        }
 
        // Lança exceção se a data for menor que a data de nascimento
        public void TimeTravel(DateTime when)
        {
            if(when <= Aniversario) {
                throw new PersonException("Se a data que voce voltar de suas ferias for menor que a data que voce nasceu o universo vai explodir!", new Exception());
            } else {
                WriteLine($"Welcome to {when:yyyy}!");
            }
        }
   }
}