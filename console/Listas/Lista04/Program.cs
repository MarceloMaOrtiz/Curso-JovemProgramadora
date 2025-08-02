using Lista04.Exercicios;

char opcao;

do
{
    Console.WriteLine("\n\n #### Menu - Lista 04 - Vetor e Função ####");
    Console.WriteLine(" 1 - Encontrar o maior e menor número");
    Console.WriteLine(" 2 - Multiplicar números");
    Console.WriteLine(" 3 - Contar Pares e Ímpares");
    Console.WriteLine(" 4 - Área do Círculo");
    Console.WriteLine(" 5 - Exponenciação");
    Console.WriteLine(" 6 - IMC");
    Console.WriteLine(" 0 - Sair");
    Console.Write("\tOpção: ");
    opcao = Convert.ToChar(Console.Read());
    Console.ReadLine();

    switch (opcao)
    {
        case '1':
            Ex01.MaiorEMenor();
            break;
        case '2':
            Ex02.Multiplicar();
            break;
        case '3':
            Ex03.ParesImpares();
            break;
        case '4':
            Ex04.AreaCirculo();
            break;
        case '5':
            Ex05.Exponenciacao();
            break;
        case '6':
            Ex06.IMC();
            break;
        case '0':
            Console.WriteLine("Fim! Grato.");
            break;
        default:
            Console.WriteLine("Opção Inválida.");
            break;
    }
    Console.WriteLine("Aperte ENTER para continuar...");
    Console.ReadLine();
} while (opcao != '0');