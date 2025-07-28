using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista01.Exercicios
{
    internal class Ex05
    {
        public static void Distancia()
        {
            double velocidade, tempo, distancia;
            Console.Write(" Velocidade (m/s): ");
            velocidade = Convert.ToDouble(Console.ReadLine());
            Console.Write(" Tempo (s): ");
            tempo = Convert.ToDouble(Console.ReadLine());

            distancia = velocidade * tempo;

            Console.WriteLine($"Foi percorrido {distancia}m.");

            Console.WriteLine("\nAperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
