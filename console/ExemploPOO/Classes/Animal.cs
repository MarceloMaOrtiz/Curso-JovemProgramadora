using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploPOO.Classes
{
    public class Animal
    {
        //public string Nome { get; set; }
        public int Idade { get; private set; }

        public string nome;
        //private int Idade;
        public string especie;
        public string classe;
        public bool vivo;

        public Animal()
        { }

        public Animal(string nome, string especie, string classe)
        {
            this.nome = nome;
            this.Idade = 0; // Quando idade = 0, significa que não sabemos a idade real
            this.especie = especie;
            this.classe = classe;
            this.vivo = true;
        }

        public Animal(string nome, int idade, string especie, string classe, bool vivo)
        {
            this.nome = nome;
            this.Idade = idade;
            this.especie = especie;
            this.classe = classe;
            this.vivo = vivo;
        }

        public void SetIdade(int idade)
        {
            if (idade < 0)
            {
                Console.WriteLine("Idade inválida. A idade não pode ser negativa.");
            }
            else
            {
                this.Idade = idade;
            }
        }

        public virtual void EmitirSom()
        {
            Console.Write($"{this.nome} está emitindo um som: ");
        }
    }
}
