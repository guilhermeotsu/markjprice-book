using System;

namespace variables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"default(int) = {default(int)}");

            Console.WriteLine($"default(double) = {default(double)}");

            Console.WriteLine($"default(bool) = {default(bool)}");

            Console.WriteLine($"default(decimal) = {default(decimal)}");

            Console.WriteLine($"default(DateTime) = {default(DateTime)}");

            Console.WriteLine($"default(string) = {default(string)}");
        }
    }
}
