using System;

namespace ExemploPOO
{
	public class Cachorro : Animal
	{
        public double Peso;

        public Cachorro() : base()
        {
        }

        public Cachorro(string nome, int idade, string especie, string classe, bool vivo, double peso) :
            base(nome, idade, especie, classe, vivo)
        {
            this.Peso = peso;
        }
    }
}
