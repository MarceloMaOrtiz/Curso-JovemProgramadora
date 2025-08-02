using System;

namespace Lista03.Exercicios
{
    public class Ex01
    {
        public Ex01()
        {
        }

        public static void ParOuImpar()
        {
            int contPar = 0, contImpar = 0, num;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Número: ");
                num = Convert.ToInt32(Console.ReadLine());
                if (num % 2 == 0) contPar++;
                else contImpar++;
            }
            Console.WriteLine($"\nQuantidade de Pares: {contPar}");
            Console.WriteLine($"Quantidade de Ímpares: {contImpar}");
        }
    }
}