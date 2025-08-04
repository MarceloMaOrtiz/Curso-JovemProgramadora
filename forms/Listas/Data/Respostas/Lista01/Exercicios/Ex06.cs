using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista01.Exercicios
{
    internal class Ex06
    {
        public static void Desconto()
        {
            const double desconto = 0.1;
            double precoOriginal, precoFinal;
            Console.Write(" Preço Original: ");
            precoOriginal = Convert.ToDouble(Console.ReadLine());
           
            precoFinal = precoOriginal - precoOriginal * desconto;

            Console.WriteLine($"O preço final é R${precoFinal}.");

            Console.WriteLine("\nAperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
