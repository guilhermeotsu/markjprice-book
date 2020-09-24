using System;
using static System.Console;

namespace Formatting
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfApples = 12;
            decimal pricePerApple = 0.35M;

            WriteLine(
                format: "{0} apple costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples
            );

            string formatted = string.Format(
                format: "{0} apples costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples
            );

            Write("Pressione alguma combinaçao de teclas: ");
            ConsoleKeyInfo key = ReadKey();
            WriteLine();
            WriteLine($"Key: {key.Key}, char {key.KeyChar}, Modifiers: {key.Modifiers}");


        }
    }
}
