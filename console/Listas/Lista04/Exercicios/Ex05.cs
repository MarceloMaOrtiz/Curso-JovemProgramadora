using System;

namespace Lista04.Exercicios
{
    public class Ex05
    {
        public Ex05()
        {
        }

        private static double CalcularExponenciacao(double nBase, int nExpoente)
        {
            double resultado = 1;
            for (int i = 0; i < nExpoente; i++)
            {
                resultado *= nBase;
            }
            return resultado;
        }

        public static void Exponenciacao()
        {
            double nBase, resultado;
            int expoente;

            Console.Write("Base: ");
            nBase = Convert.ToDouble(Console.ReadLine());
            Console.Write("Expoente: ");
            expoente = Convert.ToInt32(Console.ReadLine());

            resultado = CalcularExponenciacao(nBase, expoente);

            Console.WriteLine($"{nBase}^{expoente} = {resultado:0.##}");
        }
    }
}