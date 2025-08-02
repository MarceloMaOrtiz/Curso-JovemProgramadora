char opcao;

do
{
    Console.WriteLine("\n\n #### Menu - Lista 02 - Estrutura Condicional ####");
    Console.WriteLine(" 1 - Desconto");
    Console.WriteLine(" 2 - Verificar se um número está entre 1 e 100");
    Console.WriteLine(" 3 - Classificar Temperatura");
    Console.WriteLine(" 4 - Converter Tempo");
    Console.WriteLine(" 5 - Cálculo de Imposto");
    Console.WriteLine(" 6 - Classificar Estação");
    Console.WriteLine(" 0 - Sair");
    Console.Write("\tOpção: ");
    opcao = Convert.ToChar(Console.Read());
    Console.ReadLine();

    switch (opcao)
    {
        case '1':
            Ex01.Desconto();
            break;
        case '2':
            Ex02.ProcurarNumeroIntervalo();
            break;
        case '3':
            Ex03.ClassificarTemperatura();
            break;
        case '4':
            Ex04.ConverteTempo();
            break;
        case '5':
            Ex05.CalcularImposto();
            break;
        case '6':
            Ex06.Estacao();
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