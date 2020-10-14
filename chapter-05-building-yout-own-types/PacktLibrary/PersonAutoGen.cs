using System;

namespace PacktLibrary
{
    public partial class Person
    {
            // indices para acessar o filho de uma pessoa
        public Person this[int index] 
        {
            get {
                return Filhos[index];
            }
            set {
                Filhos[index] = value;
            }
        }

        // Readonly
        public string Origin
        {
            get;
        }

        public string Greeting => $"{Name} says 'Hello!'";
        public int Age => DateTime.Today.Year - Nascimento.Year;
        public string SorveteFavorito { get; set; }

        private string comidaFavorita;
        public string ComidaFavorita
        {
            get {
                return comidaFavorita;
            }
            set {
                switch(value.ToLower())
                {   
                    case "macarrao":
                    case "arroz":
                    case "pizza":
                        comidaFavorita = value;
                        break;
                    default:
                        throw new ArgumentException($"{value} nao é uma comida possivel");
                }
            }
        }

    }
}