using System;

namespace Lista04.Exercicios
{
    public class Ex03
    {
        public Ex03()
        {
        }

        public static void ParesImpares()
        {
            int[] numeros = new int[10];
            int contPares = 0, contImpares = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write($"{i + 1}º Número: ");
                numeros[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] % 2 == 0) contPares++;
                else contImpares++;
            }

            Console.WriteLine($"{contPares} números pares.");
            Console.WriteLine($"{contImpares} números ímpares.\n");
        }
    }
}