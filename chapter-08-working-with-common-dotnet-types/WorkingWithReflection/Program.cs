using System;
using System.Reflection;
using System.Linq;
using static System.Console;

namespace WorkingWithReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Assembly metadata: ");
            Assembly assembly = Assembly.GetEntryAssembly();
            WriteLine($"Full name: {assembly.FullName}");
            WriteLine($"Location: {assembly.Location}");
            
            var attributes = assembly.GetCustomAttributes();
            WriteLine($"Attributes: ");
            foreach (Attribute a in attributes)
                WriteLine($" {a.GetType()}");

            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            WriteLine($"Version: {version.InformationalVersion}");

            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            WriteLine($"Company: {company.Company}");

            WriteLine();
            WriteLine($"* Types:");
            Type[] types = assembly.GetTypes();
            
            foreach (Type type in types)
            {
                WriteLine($"Type: {type.FullName}");

                MemberInfo[] members = type.GetMembers();
                foreach(MemberInfo member in members)
                {
                    WriteLine($"{member.MemberType}: {member.Name} ({member.DeclaringType.Name})");

                    var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);
                    foreach (CoderAttribute coder in coders)
                    {
                        WriteLine($"-> Modified by {coder.Coder} on {coder.LastModified.ToShortDateString()}");
                    }
                }
            }    
        }

        [Coder("Guilherme Otsu", "03 November 2020")]
        [Coder("Pai ta on", "03 August 2020")]
        public static void DoStuff()
        {

        }
    }
}
