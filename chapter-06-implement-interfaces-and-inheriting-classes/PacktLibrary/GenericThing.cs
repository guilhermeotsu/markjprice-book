using System;

namespace PacktLibrary
{
    // Pode ser qualquer tipo desde que ele implemente IComparable
    public class GenericThing<T> where T : IComparable
    {
        // Inicializando a variavel Data com o valor default de T
        public T Data = default(T);
        public string Process(T input)
        {
            // retorna 0 se dois objetos saos iguais
            if(Data.CompareTo(input) == 0)
                return "Data and input are the same";
            
            return "Data and inpit are NOT the same";
        }
    }
}