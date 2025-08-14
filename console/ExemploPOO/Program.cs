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
            animal01.SetIdade(100);
            animal01.especie = "Baleia";
            animal01.classe = "Mamífero";
            animal01.vivo = true;

            Cachorro cachorro01 = new Cachorro("Rex", 5, "Cão", "Mamífero", true, 35.4);
            Gato gato01 = new Gato("Mia", 3, "Gato", "Mamífero", true, "Azul");

            Console.WriteLine(cachorro01.nome);

            Console.WriteLine(animal01.nome);
            Console.WriteLine(animal01.Idade);

            Animal animal02 = new Animal("Simba", 23, "Leão", "Mamífero", true);

            animal01.EmitirSom();
            animal02.EmitirSom();
            cachorro01.EmitirSom();
            gato01.EmitirSom();

        }
    }
}
