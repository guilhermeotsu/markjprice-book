using System;
using System.Xml.Linq;
using SharedLibrary;
using DialectSoftware.Collections;
using DialectSoftware.Collections.Generics;
using static System.Console;

namespace AssemblieAndNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");

            string str1 = "Hello!";

            str1.IsValidXmlTag();

            var doc = new XDocument();

            WriteLine();

            var x = new Axis("x", 0, 10, 1);
            var y = new Axis("y", 0, 4, 1);
            var matrix = new Matrix<long>(new[] { x, y });
            
            for(int i = 0; i < matrix.Axes[0].Points.Length; i++)
            {
                matrix.Axes[0].Points[i].Label = "x" + i.ToString();
            }

            foreach (long[] c in matrix)
            {
                matrix[c] = c[0] + c[1];
            }

            foreach (long[] c in matrix)
            {
                WriteLine("{0}, {1} ({2}, {3}) = {4}",
                    matrix.Axes[0].Points[c[0]].Label,
                    matrix.Axes[1].Points[c[1]].Label,
                    c[0], c[1], matrix[c]
                );
            }
        }
    }
}
