using System.Collections;
using System.Collections.Generic;

namespace PacktLibrary
{
    public class PersonComparer : IComparer<Person>
    {
        // Compara o tamanho do nome das instancias
        // Se for do mesmo tamanho compara os nomes em ordem alfabeticac
        public int Compare(Person x, Person y)
        {
            // Comparando o tamanho dos nomes
            int result = x.Name.Length.CompareTo(y.Name.Length);

            // se for igual
            if(result == 0) 
            {
                // Comparando em ordem alfabetica
                return x.Name.CompareTo(y.Name);
            }

            return result;
        }
    }
}