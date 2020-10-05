using System;
using static System.Console;
using static System.Convert;

namespace CastingConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conversao implícita
            int a = 10;
            double b = a;

            WriteLine(b);

            // Conversao explícita
            double c = 9.8;
            //int d = c; // Nao permite isso, pois poderá ter uma perda de informaçao
            int d = (int)c; // Perde a informaçao .8

            WriteLine(d);

            WriteLine();

            double g = 9.8;
            int h = ToInt32(g);
            WriteLine($"g is {g} and h is {h}");

            WriteLine();

            double[] doubles = new double[] { 9.49, 9.5, 9.51, 10.49, 10.50, 10.51 };

            // x = .5 
            // arredonda para cima qndo parte nao decimal for ímpar, se par para baixo
            foreach(var x in doubles)
            {
                WriteLine($"{x} to {ToInt32(x)}");
            }

            WriteLine("Usando Round:: \n");
            foreach(var x in doubles) 
            {
                // MidpointRounding.AwayFromZero é a regra de escola primária 
                WriteLine($"Math.Round({x} is {Math.Round(x, 0, MidpointRounding.AwayFromZero)})");
            }

            WriteLine();
            WriteLine();

            byte[] binaryObjects = new byte[128];

            // populando o array
            (new Random()).NextBytes(binaryObjects);
            
            WriteLine("Binary objects as bytes: ");
            
            for(int index = 0; index < binaryObjects.Length; index++)
            {
                // :X representa o output na notaçao hexadecimal
                WriteLine($"{binaryObjects[index]:X}");
            }

            WriteLine();

            // Convert to Base64 String 
            string encoded = Convert.ToBase64String(binaryObjects);

            WriteLine($"Binary Object as Base64: {encoded}");
        }
    }
}
