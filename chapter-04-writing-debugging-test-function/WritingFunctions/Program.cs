using System;
using static System.Console;

namespace WritingFunctions
{
  class Program
  {
    static void TimesTable(byte number)
    {
      WriteLine($"This is the {number} times table:");

      for (int i = 1; i <= 12; i++)
      {
        WriteLine($"{i} x {number} = {i * number}");
      }

      WriteLine();
    }

    static void RunTimesTable()
    {
      bool isNumber;

      do
      {
        WriteLine($"Insira um numero entre 0 e 255: "); ;

        isNumber = byte.TryParse(ReadLine(), out byte number);

        if (isNumber)
        {
          TimesTable(number);
        }
        else
        {
          WriteLine($"Numero invalido!");
        }
      } while (isNumber);
    }

    static decimal CalculateTax(
        decimal amount, string region
    )
    {
      decimal rate = 0.0M;

      switch (region)
      {
        case "CH":
          rate = 0.0M;
          break;
        case "CK":
        case "NO":
          rate = 0.25M;
          break;
        case "GB":
        case "FR":
          rate = 0.2M;
          break;
        case "HU":
          rate = 0.27M;
          break;
        case "OR":
        case "AK":
        case "MT":
          rate = 0.0M;
          break;
        case "ND":
        case "ME":
        case "WI":
        case "VA":
          rate = 0.05M;
          break;
        case "CA":
          rate = 0.0825M;
          break;
        default:
          rate = 0.06M;
          break;
      }

      return amount * rate;
    }

    static void RunCalculateTax()
    {
      Write("Insira um valor: ");
      string amountInput = ReadLine();

      Write("Insira uma regiao: ");
      string region = ReadLine();

      if (decimal.TryParse(amountInput, out decimal amount))
      {
        decimal taxToPay = CalculateTax(amount, region);

        WriteLine($"Voce deve pagar {taxToPay} de taxas.");
      }
      else
      {
        WriteLine("Voce inseriu um numero invalido");
      }
    }

    // Utilizando recursao
    static int Factorial(int number)
    {
        if(number < 1)
        {
            return 0;
        } 
        else if(number == 1) {
            return 1;
        }
        else {
            return number * Factorial(number - 1);
        }
    }

    static void RunFactorial() 
    {
        bool isNumber;

        Write("Insira um numero: ");

        isNumber = int.TryParse(ReadLine(), out int number);

        if(isNumber) 
        {
            WriteLine($"{number:N0}! = {Factorial(number):N0}");
        } 
        else {
            WriteLine("Numero invalido!");
        }
    }

    static double Add(double a, double b)
    {
        return a + b;
    }
    static void Main(string[] args)
    {
        double a = 4.5;
        double b = 2.5;

        double answer  = Add(a, b);

        WriteLine($"{a} + {b} = {answer}");

        ReadLine();
    }
  }
}
