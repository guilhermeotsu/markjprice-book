using System;
using System.Security.Claims;
using System.Threading;
using CryptographyLib;
using static System.Console;

namespace SecureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Protector.Register("Alice", "Pa$$w0rd", new[] { "Admins" });
            Protector.Register("Bob", "Pa$$w0rd", new[] { "Vendas", "Gerente" });
            Protector.Register("Guilherme", "Pa$$w0rd", new[] { "Dev" });
            Protector.Register("Vanessa", "Pa$$w0rd", new[] { "Dev", "Infra" });

            Write("Entre com seu usuário: ");
            string userName = ReadLine();

            Write("Entre com sua senha: ");
            string password = ReadLine();

            Protector.LogIn(userName, password);

            if (ReferenceEquals(Thread.CurrentPrincipal, null))
            {
                WriteLine("Falha ao fazer o login!\nVerifique suas credenciais e tente novamente.");
                return;
            }

            // Usuario que está logado
            var principal = Thread.CurrentPrincipal;

            WriteLine($"IsAuthenticated: {principal.Identity.IsAuthenticated}");
            WriteLine($"AuthenticatedType: {principal.Identity.AuthenticationType}");
            WriteLine($"Name: {principal.Identity.Name}");
            WriteLine($"IsInRole(\"Admins\"): {principal.IsInRole("Admins")}");
            WriteLine($"IsInRole(\"Vendas\"): {principal.IsInRole("Vendas")}");
            WriteLine($"IsInRole(\"Gerente\"): {principal.IsInRole("Gerente")}");
            WriteLine($"IsInRole(\"Dev\"): {principal.IsInRole("Dev")}");
            WriteLine($"IsInRole(\"Infra\"): {principal.IsInRole("Infra")}");

            if(principal is ClaimsPrincipal)
            {
                WriteLine($"{principal.Identity.Name} tem os seguintes claims: ");
                
                foreach (Claim claim in (principal as ClaimsPrincipal).Claims)
                {
                    WriteLine($"{claim.Type}: {claim.Value}");
                } 
            }
        }
    }
}
