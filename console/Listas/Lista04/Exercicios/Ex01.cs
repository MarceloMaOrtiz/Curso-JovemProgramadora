using System;

namespace Lista04.Exercicios
{
    public class Ex01
    {
        public Ex01()
        {
        }

        public static void MaiorEMenor()
        {
            int[] numeros = new int[10];
            int maior, menor;

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write($"{i + 1}º Número: ");
                numeros[i] = Convert.ToInt32(Console.ReadLine());
            }

            maior = numeros[0];
            menor = numeros[0];

            for (int i = 1; i < numeros.Length; i++)
            {
                if( numeros[i] > maior ) maior = numeros[i];
                if( numeros[i] < menor ) menor = numeros[i];
            }

            Console.WriteLine($"Maior: {maior}");
            Console.WriteLine($"Menor: {menor}");

        }
    }
}