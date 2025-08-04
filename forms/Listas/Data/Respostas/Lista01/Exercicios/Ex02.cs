using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista01.Exercicios
{
    internal class Ex02
    {
        public static void ConverterTemperatura()
        {
            double celsius, fahrenheit;
            Console.Write("Insira a temperatura em Cº: ");
            celsius = Convert.ToDouble(Console.ReadLine());

            fahrenheit = celsius * 9 / 5 + 32;

            Console.WriteLine($"{celsius}Cº = {fahrenheit}F");

            Console.WriteLine("\nAperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
