using System;
using static System.Console;

namespace HandlingExceptions
{
  class Program
  {
    static void Main(string[] args)
    {
      WriteLine("Before parsing");
      WriteLine("Qual sua idade?");

      string input = ReadLine();


      try
      {
        int idade = int.Parse(input);
        WriteLine($"Sua idade é {idade}");
      }
      // É possível adicionar um block catch para cada exceçao
      catch (OverflowException)
      {
          WriteLine("Sua idade é um número válido mas ela é muito grande, ou pequena");
      }
      catch (FormatException)
      {
        WriteLine("A idade inserida não é um número válido");
      }
      catch (Exception ex)
      {
        WriteLine($"{ex.GetType()} say: {ex.Message}");
      }

      WriteLine("After parsing");
    }
  }
}
