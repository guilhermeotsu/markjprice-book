using System;
using System.IO;
using static System.Console;

namespace BooleanOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = true;
            bool b = false;

            WriteLine($"AND | a | b ");
            WriteLine($"a | {a & a, -5} | { a & b, -5 }");
            WriteLine($"b | {b & a, -5} | {b & b, -5}");
            WriteLine();
            WriteLine($"OR | a | b");
            WriteLine($"a | { a | a, -5}");
            WriteLine($"b | {b | a, -5} | {b | b, -5}");
            WriteLine();
            WriteLine($"XOR | a | b");
            WriteLine($"a | {a ^ a, -5} | {a ^ b, -5}");
            WriteLine($"b | {b ^a, -5} | {b ^ b, -5}");

            WriteLine();

            WriteLine($"a & DoStuff() = { a & DoStuff() }"); 
            WriteLine($"b & DoStuff() = { a & DoStuff() }");

            WriteLine();

            object o = "3";

            if(o is int i) {
                WriteLine($"o  is int");
            } else {
                WriteLine($"o is not int");
            }

            A_label: var number = (new Random()).Next(1, 5);

            string path = @"C:\src\dev\csharp\book-markjprice\chapter-03-controlling-flows-converting-types";
            
            // Foi declarado como Stream, ele vai assunmir o valor de um subtipo FileStream ou MemoryStream
            Stream s = File.Open(Path.Combine(path, "file.txt"), FileMode.Open);
            string message = string.Empty;

            // Tomando decisoes baseado no subtipo da Stream, matendo o codigo mais seguro
            switch(s) {
                // a palavra chave when está deixando o patter matching mais específica, onde só vai cair nesse case
                // se o o tipo s for FileStreeam e CanWrite for true
                case FileStream writeableFile when s.CanWrite: 
                    message = "The stream is a file that i can write to.";
                    break;
                case FileStream readOnlyFile: 
                    message = "The stream is read-only file.";
                    break;
                case MemoryStream ms:
                    message = "The stream is a memory address";
                    break;
                default: 
                    message = "The stream is some ohter type.";
                    break;
                case null: 
                    message = "The stream is null.";
                    break;
            }

            // Simplificando o switch case, só funciona no C# 8.0 +, muito mais facil
            message = s switch
            {
                FileStream writeableFile when s.CanWrite
                    => "The stream is a file that i can write to.",
                FileStream readOnlyFile
                    => "The stream is read-only file.",
                MemoryStream ms
                    => "The stream is a memory address",
                null
                    => "The stream is null.",
                _ // Representa o valor default
                    => "The stream is some ohter type."
            };

            WriteLine(message);
        }

        static bool DoStuff() {
            WriteLine("I am doing some stuff");

            return true;
        }
    }
}
