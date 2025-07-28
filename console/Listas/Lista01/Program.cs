using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lista01.Exercicios;

namespace lista01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char opcao;

            do
            {
                Console.WriteLine("\n\n #### Menu - Lista 01 ####");
                Console.WriteLine(" 1 - Área do Retângulo");
                Console.WriteLine(" 2 - Converter Celsius para Fahrenheit");
                Console.WriteLine(" 3 - Média Simples");
                Console.WriteLine(" 4 - Juros Simples");
                Console.WriteLine(" 5 - Distância Percorrida");
                Console.WriteLine(" 6 - Desconto");
                Console.WriteLine(" 7 - Troco");
                Console.WriteLine(" 8 - Consumo de Combustível");
                Console.WriteLine(" 9 - Salário Líquido");
                Console.WriteLine(" 0 - Sair");
                Console.Write("\tOpção: ");
                opcao = Convert.ToChar(Console.ReadLine());

                switch (opcao)
                {
                    case '1':
                        Ex01.AreaRetangulo();
                        break;
                    case '2':
                        Ex02.ConverterTemperatura();
                        break;
                    case '3':
                        Ex03.MediaSimples();
                        break;
                    case '4':
                        Ex04.JurosSimples();
                        break;
                    case '5':
                        Ex05.Distancia();
                        break;
                    case '6':
                        Ex06.Desconto();
                        break;
                    case '7':
                        Ex07.Troco();
                        break;
                    case '8':
                        Ex08.ConsumoCombustivel();
                        break;
                    case '9':
                        Ex09.SalarioLiquido();
                        break;
                    case '0':
                        Console.WriteLine("Fim! Grato.");
                        break;
                    default:
                        Console.WriteLine("Opção Inválida.");
                        break;
                }
            } while (opcao != '0');
            
            
        }
    }
}
