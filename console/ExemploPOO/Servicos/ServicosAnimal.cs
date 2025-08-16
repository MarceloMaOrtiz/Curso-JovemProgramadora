using ExemploPOO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploPOO.Servicos
{
    public class ServicosAnimal
    {
        public static void Run()
        {
            // ExemplosSimples();
            ExemplosLista();
        }

        public static void ExemplosLista()
        {
            List<Animal> lista = new List<Animal>();

            Cachorro cachorro01 = new Cachorro("Hulk", 8, "Vira Lata", "Mamífero", true, 8.4);
            Cachorro cachorro02 = new Cachorro("Fefe", 24, "Pincher", "Mamífero", true, 4.4);
            Cachorro cachorro03 = new Cachorro("Filó", 8, "Pitbull", "Mamífero", true, 7);

            Gato gato01 = new Gato("Mimi", 3, "Siamês", "Mamífero", true, "Verde");
            Gato gato02 = new Gato("Zizi", 2, "Persa", "Mamífero", true, "Azul");
            Gato gato03 = new Gato("Lili", 1, "Siamês", "Mamífero", true, "Amarelo");

            lista.Add(cachorro01);
            lista.Add(gato03);
            lista.Add(gato02);
            lista.Add(cachorro03);
            lista.Add(cachorro02);
            lista.Add(gato01);

            foreach (Animal animal in lista)
            {
                animal.EmitirSom();
            }
        }

        public static void ExemplosSimples()
        {
            Animal animal01 = new Animal();
            animal01.nome = "Laboom";
            animal01.SetIdade(100);
            animal01.especie = "Baleia";
            animal01.classe = "Mamífero";
            animal01.vivo = true;

            Animal animal02 = new Animal("Simba", 23, "Leão", "Mamífero", true);

            Cachorro cachorro01 = new Cachorro("Rex", 5, "Cão", "Mamífero", true, 35.4);
            Gato gato01 = new Gato("Mia", 3, "Gato", "Mamífero", true, "Azul");

            Console.WriteLine(cachorro01.nome);

            Console.WriteLine(animal01.nome);
            Console.WriteLine(animal01.Idade);

            animal01.EmitirSom();
            animal02.EmitirSom();
            cachorro01.EmitirSom();
            gato01.EmitirSom();
        }
    }
}
