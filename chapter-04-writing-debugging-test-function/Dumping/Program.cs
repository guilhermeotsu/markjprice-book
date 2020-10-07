using System;
using static System.Console;
using System.Threading.Tasks;
using SharpPad;

namespace Dumping
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var complexOj = new {
                FirstName = "Guilherme",
                BirthDate = new DateTime(year: 1998, month: 12, day: 24),
                Frieds = new [] { "Amir", "Fred", "Giu" }
            };

            WriteLine($"Dumping {nameof(complexOj)} to SharpPad");

            await complexOj.Dump();
        }
    }
}
