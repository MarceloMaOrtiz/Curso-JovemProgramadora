using System;

namespace Lista04.Exercicios
{
    public class Ex06
    {
        public Ex06()
        {
        }

        private static double CalcularIMC(double peso, double altura)
        {
            return peso / (altura * altura);
        }
        public static void IMC()
        {
            double peso, altura, imc;
            Console.Write("Peso (kg): ");
            peso = Convert.ToDouble(Console.ReadLine());
            Console.Write("Altura (m): ");
            altura = Convert.ToDouble(Console.ReadLine());

            imc = CalcularIMC(peso, altura);

            Console.WriteLine($"IMC = {imc:0.##}kg/m²");
        }
    }
}