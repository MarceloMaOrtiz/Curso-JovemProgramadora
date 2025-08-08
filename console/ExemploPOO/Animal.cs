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
        //public int Idade { get; set; }

        public string nome;
        public int idade;
        public string especie;
        public string classe;
        public bool vivo;

        public Animal()
        { }

        public Animal(string nome, int idade, string especie, string classe, bool vivo)
        {
            this.nome = nome;
            this.idade = idade;
            this.especie = especie;
            this.classe = classe;
            this.vivo = vivo;
        }
    }
}
