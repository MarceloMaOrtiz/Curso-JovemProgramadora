using System;

namespace Lista04.Exercicios
{
    public class Ex02
    {
        public Ex02()
        {
        }

        public static void Multiplicar()
        {
            int[] numeros = new int[5];

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write($"{i + 1}º Número: ");
                numeros[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.WriteLine($"{numeros[i]} * 2 = {numeros[i] * 2}");
            }
        }
    }
}