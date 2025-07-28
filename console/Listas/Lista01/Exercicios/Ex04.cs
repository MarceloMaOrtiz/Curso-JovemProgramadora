using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista01.Exercicios
{
    internal class Ex04
    {
        public static void JurosSimples()
        {
            double capitalInicial, taxaJuros, tempo, juros;
            Console.Write(" Capital Inicial: ");
            capitalInicial = Convert.ToDouble(Console.ReadLine());
            Console.Write(" Taxa de Juros Anual (%): ");
            taxaJuros = Convert.ToDouble(Console.ReadLine());
            Console.Write(" Tempo em anos: ");
            tempo = Convert.ToDouble(Console.ReadLine());

            juros = capitalInicial * taxaJuros / 100 * tempo;

            Console.WriteLine($"O juros é R${juros}.");

            Console.WriteLine("\nAperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
