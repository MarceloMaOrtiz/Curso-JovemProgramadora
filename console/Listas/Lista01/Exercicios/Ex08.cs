using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista01.Exercicios
{
    internal class Ex08
    {
        public static void ConsumoCombustivel()
        {
            double distancia, consumoMedio, litrosUsado;
            Console.Write(" Distancia Percorrida: ");
            distancia = Convert.ToDouble(Console.ReadLine());
            Console.Write(" Consumo Médio (km/l): ");
            consumoMedio = Convert.ToDouble(Console.ReadLine());

            litrosUsado = distancia / consumoMedio;

            Console.WriteLine($"Foram utilizados {litrosUsado} litros.");

            Console.WriteLine("\nAperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
