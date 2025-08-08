using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal animal01 = new Animal();
            animal01.nome = "Laboom";
            animal01.idade = 100;
            animal01.especie = "Baleia";
            animal01.classe = "Mamífero";
            animal01.vivo = true;

            Animal animal02 = new Animal("Simba", 23, "Leão", "Mamífero", true);
        }
    }
}
