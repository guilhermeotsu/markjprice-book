using System;

namespace nullHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            var addres = new Address();
            addres.Building = null;
            addres.Street = null;
            addres.City = "London";
            addres.Region = null;
        }

        static void Testes()
        {
            
            int cannotBeNull = 4;

            // cannotBeNull = null; // error

            int? couldBeNull = null;

            Console.WriteLine(couldBeNull);
            Console.WriteLine(couldBeNull.GetValueOrDefault());

            couldBeNull = 7;

            Console.WriteLine(couldBeNull);
            Console.WriteLine(couldBeNull.GetValueOrDefault());
        }
    }

    class Address 
    { 
        public string? Building;
        public string Street = string.Empty;
        public string City = string.Empty;
        public string Region = string.Empty;
    }
}
