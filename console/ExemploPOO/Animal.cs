using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploPOO
{
    public class Animal
    {
        //public string Nome { get; set; }
        public int Idade { get; protected set; }

        public string nome;
        public string especie;
        public string classe;
        public bool vivo;

        public Animal()
        { }

        public Animal(string nome, int idade, string especie, string classe, bool vivo)
        {
            this.nome = nome;
            this.SetIdade(idade);
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

        public void EmitirSom()
        {
            Console.WriteLine("Som de animal");
        }
    }
}
