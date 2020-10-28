using System;
using System.Threading;

namespace PacktLibrary
{
    public static class Squarer
    {
        public static double Square<T>(T input) where T : IConvertible
        {
            // Convertendo usando cultura corrente
            double d = input.ToDouble(Thread.CurrentThread.CurrentCulture);

            return d * d;
        }
    }
}