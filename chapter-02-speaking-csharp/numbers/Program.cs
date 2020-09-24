using System;

namespace numbers
{
    class Program
    {
        static void Main(string[] args)
        {
           Useful();
        }

        public static void Numbers()
        {
             // numeros inteiros incluindo 0
            uint naturalNumber = 23;

            // inteiros que podem ser negativos
            int integerNumber =  -23;

            // float single precision
            // sufixo F representa um float literal
            float realNumber = 2.3F;

            // double precision
            double anotherRealNumber = 2.3;

            // underscore - usado apenas para melhorar a legibilidade, é ignorado pelo compilador
            int mil = 1_000;
            int million = 1_000_000;

            // para escrever um numero binario comece com 0b
            // hexadecimal com 0x

            // 2 million
            int decimalNotation = 2_000_000;
            int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
            int hexadecimalNotation = 0x_001E_8480;

            Console.WriteLine($"{decimalNotation == binaryNotation}");
            Console.WriteLine($"{decimalNotation == hexadecimalNotation}");

            Console.WriteLine($"\n\nint utilizar {sizeof(int)} bytes e pode armazenar no minimo ${int.MinValue:N0} até {int.MaxValue:N0)}");
            Console.WriteLine($"\n\ndouble utilizar {sizeof(double)} bytes e pode armazenar no minimo ${double.MinValue:N0} até {double.MaxValue:N0)}");
            Console.WriteLine($"\n\ndecimal utilizar {sizeof(decimal)} bytes e pode armazenar no minimo ${decimal.MinValue:N0} até {decimal.MaxValue:N0)}");

            Console.WriteLine("\n\nusing double: ");
            double a = 0.1;
            double b = 0.2;

            if(a + b == 0.3) {
                System.Console.WriteLine($"${a} + {b} equals 0.3");
            } else {
                System.Console.WriteLine($"{a} + {b} does not equal 0.3");
            }
        }

        public static void Useful()
        {
            Console.WriteLine($"NaN {double.NaN}\nEpsilon {double.Epsilon}\nInfinity {double.PositiveInfinity}");
        }
    }
}
