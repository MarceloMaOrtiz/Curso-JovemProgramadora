using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista01.Exercicios
{
    internal class Ex07
    {
        public static void Troco()
        {
            double valorProduto, valorPago, troco;
            Console.Write(" Valor do Produto: ");
            valorProduto = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Valor do Pago: ");
            valorPago = Convert.ToDouble(Console.ReadLine());

            troco = valorPago - valorProduto;

            Console.WriteLine($"Troco = R${troco}.");

            Console.WriteLine("\nAperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
