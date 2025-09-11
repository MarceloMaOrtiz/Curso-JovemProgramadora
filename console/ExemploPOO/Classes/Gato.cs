using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploPOO.Classes
{
    public class Gato : Animal
    {
        public string CorOlhos;

        public Gato() : base()
        {
        }

        public Gato(string nome, int idade, string especie, string classe, bool vivo, string corOlhos) :
            base(nome, idade, especie, classe, vivo)
        {
            this.CorOlhos = corOlhos;
        }

        public override void EmitirSom()
        {
            base.EmitirSom();
            Console.WriteLine("Miau");
        }
    }
}
