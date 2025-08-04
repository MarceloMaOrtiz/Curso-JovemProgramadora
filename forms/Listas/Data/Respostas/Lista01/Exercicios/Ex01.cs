using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista01.Exercicios
{
    internal class Ex01
    {

        public static void AreaRetangulo()
        {
            double altura, largura, area;
            Console.Write("Insira a Altura do Retângulo (cm): ");
            altura = Convert.ToDouble(Console.ReadLine());
            Console.Write("Insira a Largura do Retângulo (cm): ");
            largura = Convert.ToDouble(Console.ReadLine());

            area = altura * largura;

            Console.WriteLine($"A área do retângulo é {area}cm².");

            Console.WriteLine("\nAperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
