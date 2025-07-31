char opcao;

do
{
    Console.WriteLine("\n\n #### Menu - Lista 03 - Estrutura de Repetição ####");
    Console.WriteLine(" 1 - Classificar números Pares ou Ímpares");
    Console.WriteLine(" 2 - Repetir até número maior ou igual a 100");
    Console.WriteLine(" 3 - Correção Salarial");
    Console.WriteLine(" 4 - Jogo: Encontrando o número");
    Console.WriteLine(" 0 - Sair");
    Console.Write("\tOpção: ");
    opcao = Convert.ToChar(Console.Read());
    Console.ReadLine();

    switch (opcao)
    {
        case '1':
            Ex01.ParOuImpar();
            break;
        case '2':
            Ex02.RepetirAteCondicao();
            break;
        case '3':
            Ex03.CorrecaoSalarial();
            break;
        case '4':
            Ex04.EncontrandoNumero();
            break;
        case '0':
            Console.WriteLine("Fim! Grato.");
            break;
        default:
            Console.WriteLine("Opção Inválida.");
            break;
    }
} while (opcao != '0');