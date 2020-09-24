using System;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type\tBytes(s) of memory\t\tmin\t\tMax");
            Console.WriteLine($"sbyte\t{sizeof(sbyte)}\t\t\t{sbyte.MinValue}\t\t\t{sbyte.MaxValue}");
            Console.WriteLine($"byte\t{sizeof(byte)}\t\t\t{byte.MinValue}\t\t\t{byte.MaxValue}");
            Console.WriteLine($"short\t{sizeof(short)}\t\t\t{short.MinValue}\t\t\t{short.MaxValue}");
            Console.WriteLine($"ushort\t{sizeof(ushort)}\t\t\t{ushort.MinValue}\t\t\t{ushort.MaxValue}");
            Console.WriteLine($"ushort\t{sizeof(ushort)}\t\t\t{ushort.MinValue}\t\t\t{ushort.MaxValue}");
            Console.WriteLine($"int\t{sizeof(int)}\t\t\t{int.MinValue}\t\t\t{int.MaxValue}");
            Console.WriteLine($"uint\t{sizeof(uint)}\t\t\t{uint.MinValue}\t\t\t{uint.MaxValue}");
            Console.WriteLine($"long\t{sizeof(long)}\t\t\t{long.MinValue}\t\t\t{long.MaxValue}");
            Console.WriteLine($"ulong\t{sizeof(ulong)}\t\t\t{ulong.MinValue}\t\t\t{ulong.MaxValue}");
            Console.WriteLine($"float\t{sizeof(float)}\t\t\t{float.MinValue}\t\t\t{float.MaxValue}");
            Console.WriteLine($"double\t{sizeof(double)}\t\t\t{double.MinValue}\t\t\t{double.MaxValue}");
            Console.WriteLine($"decimal\t{sizeof(decimal)}\t\t\t{decimal.MinValue}\t\t\t{decimal.MaxValue}");
        }
    }
}
