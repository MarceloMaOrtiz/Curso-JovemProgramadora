using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploPOO.Servicos;

namespace ExemploPOO
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Animais");
                Console.WriteLine("2 - Aleatório");
                Console.WriteLine("0 - Sair");

                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Você escolheu Animais.");
                        // Aqui você pode chamar o método que lida com animais
                        ServicosAnimal.Run();
                        break;
                    case 2:Console.WriteLine("Você escolheu Aleatório.");
                        // Aqui você pode chamar o método que lida com aleatórios
                        ServicosAleatorios.Run();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();

            } while (opcao != 0);
        }
    }
}
