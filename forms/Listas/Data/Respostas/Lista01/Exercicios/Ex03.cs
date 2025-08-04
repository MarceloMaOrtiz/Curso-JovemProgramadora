using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista01.Exercicios
{
    internal class Ex03
    {
        public static void MediaSimples()
        {
            double nota1, nota2, nota3, media;
            Console.WriteLine("Calculando a média de 3 notas.");
            Console.Write("\t Nota 1: ");
            nota1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("\t Nota 2: ");
            nota2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("\t Nota 3: ");
            nota3 = Convert.ToDouble(Console.ReadLine());

            media = (nota1 + nota2 + nota3) / 3;

            Console.WriteLine($"A média das três notas é {media}.");

            Console.WriteLine("\nAperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
