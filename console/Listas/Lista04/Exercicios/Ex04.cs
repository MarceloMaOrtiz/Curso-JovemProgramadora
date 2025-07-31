using System;

namespace Lista04.Exercicios
{
    public class Ex04
    {
        const double PI = 3.14159265359;
        public Ex04()
        {
        }

        private static double CalcularArea(double raio)
        {
            return PI * raio * raio;
        }

        public static void AreaCirculo()
        {
            double raio, area;
            Console.Write("Raio (cm): ");
            raio = Convert.ToDouble(Console.ReadLine());
            area = CalcularArea(raio);
            Console.WriteLine($"A área do círculo de raio {raio:0.##}cm é {area:0.##}cm²");
        }
    }
}