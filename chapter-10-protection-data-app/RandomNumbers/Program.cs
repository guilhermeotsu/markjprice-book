using System;
using CryptographyLib;
using static System.Console;

namespace RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Quao grande voce quer o tamanho da sua chave? (em bytes): ");
            string size = ReadLine();

            byte[] key = Protector.GetRandomKeyOrIV(int.Parse(size));

            WriteLine("Chave como um byte de array: ");
            for(int i = 0;i < key.Length; i++)
            {
                Write($"{key[i]:x2} ");
                
                if(((i + 1) % 16) == 0)
                WriteLine();
            }

            WriteLine();
        }
    }
}
