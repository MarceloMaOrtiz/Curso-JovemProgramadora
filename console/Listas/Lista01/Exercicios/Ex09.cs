using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista01.Exercicios
{
    internal class Ex09
    {
        public static void SalarioLiquido()
        {
            const double imposto = 0.08;
            double salarioBruto, salarioLiquido;
            Console.Write(" Salário Bruto: ");
            salarioBruto = Convert.ToDouble(Console.ReadLine());

            salarioLiquido = salarioBruto - salarioBruto*imposto;

            Console.WriteLine($"Salário Líquido = R${salarioLiquido}.");

            Console.WriteLine("\nAperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
