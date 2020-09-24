using System;
using System.Linq;
using System.Reflection;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            double heighInMetres = 1.88;

            //System.Console.WriteLine($"The variable {nameof(heighInMetres)} has the value {heighInMetres}");

            int? dale = null;
            int? dele = 1;

            dale ??= 8080; // atribui a variavel pelo valor a esquerda se ela estiver com o valor nulo;
            dele ??= 20;

            System.Console.WriteLine($"valor de {nameof(dale)} é {dale}");
            System.Console.WriteLine($"valor de {nameof(dele)} é {dele}");
        }

        static void Assemblies()
        {
            // assemblies qu esse app faz referencia
            foreach (var item in Assembly.GetEntryAssembly()
                                .GetReferencedAssemblies())
            {
                // carrega o assembly para ler os detalhes
                var a = Assembly.Load(new AssemblyName(item.FullName));

                // numero de metodos
                int methodCount = 0;

                // loop atraves de todos os tipos no assembly
                foreach (var t in a.DefinedTypes)
                {
                    methodCount += t.GetMethods().Count();
                }

                System.Console.WriteLine(
                    "{0:N0} tipos com {1:N0} metódos em {2} assembly",
                    arg0: a.DefinedTypes.Count(),
                    arg1: methodCount,
                    arg2: item.Name
                );
            }
        }
    }
}
