using System;
using CryptographyLib;
using static System.Console;

namespace HashApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("registrando Alice com a senha Pa$$w0rd.");
            var alice = Protector.Register("Alice", "Pa$$w0rd");

            WriteLine($"Name: {alice.Name}");
            WriteLine($"Salt: {alice.Salt}");

            WriteLine($"Password (salted and hashed) {alice.SaltedHashedPassword}");

            WriteLine();
            WriteLine("Entre com um novo usuário!");
            Write("Insira o Nome: ");
            string userName = ReadLine();
            Write("Insira a senha: ");
            string password = ReadLine();

            try
            {
                var user = Protector.Register(userName, password);

                WriteLine($"Usuário {user.Name}");
                WriteLine($"Senha pura: {password}");
                WriteLine($"Salt gerado: {user.Salt}");
                WriteLine($"Senha com salt e hash {user.SaltedHashedPassword}");

                WriteLine();

                WriteLine("Tente Logar no sistema!");

                bool correctPassword = false;
                while (!correctPassword)
                {
                    WriteLine("Entre com usuario para logar no sistema!");
                    Write("Insira o user para logar: ");
                    string userNameLogin = ReadLine();
                    Write("Insira a senha para logar: ");
                    string passwordLogin = ReadLine();

                    correctPassword = Protector.CheckPassword(userNameLogin, passwordLogin);

                    if (correctPassword)
                    {
                        WriteLine($"Logado!\nUsuário e senha válido.");
                    }
                    else
                    {
                        WriteLine("Falha ao logar!\nTente novamente\n");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}
