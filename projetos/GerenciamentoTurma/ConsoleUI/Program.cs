using ConsoleUI.UI;

int menu;

//int num;
//Console.Write("Insira o num: ");
//num = Convert.ToInt32(Console.ReadLine());

//try
//{
//    int num;
//    Console.Write("Insira o num: ");
//    num = Convert.ToInt32(Console.ReadLine());
//}
//catch (FormatException e)
//{
//    Console.WriteLine("Você não digitou um número.");
//    Console.WriteLine(e.Message);
//}
//catch (OverflowException)
//{
//       Console.WriteLine("Número muito grande ou muito pequeno.");
//}catch(Exception e)
//{
//    Console.WriteLine("Ocorreu um erro inesperado.");
//    Console.WriteLine(e.Message);
//}

UIAluno.TestarConexao();

do
{
    Console.Write("\n\n Menu Principal:\n1 - Cadastrar aluno\n2 - Remover Aluno\n3 - Buscar Aluno\n4 - Listar todos os Alunos\n5 - Listar Alunos Aprovados\n6 - Listar Alunos Reprovados\n7 - Sair\nOpção: ");
    menu = Convert.ToInt32(Console.ReadLine());

    switch (menu)
    {
        case 1:
            UIAluno.CadastroAluno();
            break;
        case 2:
            UIAluno.RemoverAluno();
            break;
        case 3:
            UIAluno.BuscarAluno();
            break;
        case 4:
            UIAluno.ListarAtivos();
            break;
        case 5:
            UIAluno.ListarAprovados();
            break;
        case 6:
            UIAluno.ListarReprovados();
            break;
        case 7:
            Console.WriteLine("\nPrograma encerrado!");
            break;
        default:
            Console.WriteLine("\nOpção inválida!");
            break;
    }
    UIAluno.LimparTela();
} while (menu != 7);