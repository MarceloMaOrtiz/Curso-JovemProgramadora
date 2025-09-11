using System;

namespace ExemploPOO.Classes
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

        public override void EmitirSom()
        {
            base.EmitirSom();
            Console.WriteLine("Au Au");
        }
    }
}
