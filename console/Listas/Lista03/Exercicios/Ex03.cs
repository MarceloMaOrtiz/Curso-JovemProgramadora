using System;

namespace Lista03.Exercicios
{
    public class Ex03
    {
        public Ex03()
        {
        }

        public static void CorrecaoSalarial()
        {
            char[] generos = ['M', 'm', 'F', 'f'];
            string nome;
            char genero;
            double aumento = 0, salarioInicial, salarioFinal;
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine() ?? "";
                do
                {
                    Console.Write("Gênero (M - Masculino | F - Feminino): ");
                    genero = (char)Console.Read();
                    Console.ReadLine();
                    if (genero == 'M' || genero == 'm') aumento = 0.03;
                    else if (genero == 'F' || genero == 'f') aumento = 0.05;
                    else Console.WriteLine($"Gênero {genero} inválido");

                } while (!generos.Contains(genero));
                Console.Write("Salário: ");
                salarioInicial = Convert.ToInt32(Console.ReadLine());
                salarioFinal = salarioInicial + salarioInicial * aumento;

                Console.WriteLine($"Nome: {nome}");
                Console.WriteLine($"Salário Inicial: {salarioInicial}");
                Console.WriteLine($"Salário Final: {salarioFinal}\n");
            }
        }
    }
}