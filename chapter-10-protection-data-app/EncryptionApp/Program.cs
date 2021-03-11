using System;
using System.Security.Cryptography;
using CryptographyLib;
using static System.Console;


namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
           Write("Entre com uma mensagem que deseja criptografar: ");
           string message = ReadLine();

           Write("Insira a senha: ");
           string password = ReadLine();

           string cryptoText = Protector.Encrypt(message, password);
           WriteLine($"Texto criptografado {cryptoText}");
           Write("Insira a senha: ");
           string password2 = ReadLine();

           try {
               string clearText = Protector.Decrypt(cryptoText, password2);
               WriteLine($"Texto descriptografado: {clearText}");
           } 
           catch(CryptographicException ex)
           {
               WriteLine($"Voce inseriu a senha incorreta! {ex.Message}");
           }
           catch(Exception ex)
           {
               WriteLine($"Exception Nao-Criptografica: {ex.GetType().Name}, {ex.Message}");
           }
        }
    }
}
