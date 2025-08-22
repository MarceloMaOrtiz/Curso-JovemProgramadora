using ConsoleUI.UI;

int menu;

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
            //RemoverAluno(matriz);
            break;
        case 3:
            //BuscarAluno(matriz);
            break;
        case 4:
            UIAluno.ListarAtivos();
            break;
        case 5:
            //Media(matriz, 5);
            break;
        case 6:
            //Media(matriz, 6);
            break;
        case 7:
            Console.WriteLine("\nPrograma encerrado!");
            break;
        default:
            Console.WriteLine("\nOpção inválida!");
            break;
    }
} while (menu != 7);