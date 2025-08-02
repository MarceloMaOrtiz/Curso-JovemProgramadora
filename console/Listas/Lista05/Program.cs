using Lista05.Exercicios;

char opcao;

do
{
    Console.WriteLine("\n\n #### Menu - Lista 05 - Matriz ####");
    Console.WriteLine(" 1 - Preencher e Exibir uma matriz 3x3");
    Console.WriteLine(" 2 - Gerar matriz Identidade");
    Console.WriteLine(" 3 - Mostrar a soma das linhas e colunas");
    Console.WriteLine(" 4 - Matriz de presenças para 3 alunos e 5 dias");
    Console.WriteLine(" 5 - Encontrar valor na matriz e retornar o índice");
    Console.Write("\tOpção: ");
    opcao = Convert.ToChar(Console.Read());
    Console.ReadLine();

    switch (opcao)
    {
        case '1':
            Ex01.PreencherExibir();
            break;
        case '2':
            Ex02.MatrizIdentidade();
            break;
        case '3':
            Ex03.SomaLinhasColunas();
            break;
        case '4':
            Ex04.Presencas();
            break;
        case '5':
            Ex05.EncontrarValor();
            break;
        case '0':
            Console.WriteLine("Fim! Grato.");
            break;
        default:
            Console.WriteLine("Opção Inválida.");
            break;
    }
    Console.WriteLine("Pressione ENTER para continuar...");
    Console.ReadLine();
} while (opcao != '0');