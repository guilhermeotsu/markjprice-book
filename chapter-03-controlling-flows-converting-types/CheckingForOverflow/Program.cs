using System;
using static System.Console;

namespace CheckingForOverflow
{
  class Program
  {
    // A palavra chave checked habilita os lançamento de exceçoes de forma explícita para inteiros
    // Isso é util para fazermos tratamento de erros de maneira mais agradável
    static void Main(string[] args)
    {

      int x = int.MaxValue - 1;

      WriteLine($"Valor inicial: {x}");
      x++;

      WriteLine($"Depois de incrementar: {x}");
      x++;

      WriteLine($"Depois de incrementar: {x}");
      x++;

      WriteLine($"Depois de incrementar: {x}");

      //int y = int.MaxValue + 1;

      double j = 10;

      WriteLine(j / 0);

      // while(true)

      // for (; true;)
      // {
      //   WriteLine("infinito");
      // }

      int max = 500;

      for(byte i = 0; i < max; i++) 
        WriteLine(i);
    }
  }
}
