using AlunosConsole;
using AlunosModels.ValueObject;

int menu;

do
{
    //UI.TestarConexao();
    try
    {
        UI.LimpaTela();
        Console.Write("Menu Principal:\n1 - Cadastrar aluno\n2 - Remover Aluno\n3 - Buscar Aluno\n4 - Listar todos os Alunos\n5 - Listar Alunos Aprovados\n6 - Listar Alunos Reprovados\n7 - Sair\nOpção: ");
        menu = Convert.ToInt32(Console.ReadLine());

        switch (menu)
        {
            case 1:
                UI.CadastrarAluno();
                break;
            case 2:
                UI.RemoverAluno();
                break;
            case 3:
                UI.BuscarAlunoCpf();
                break;
            case 4:
                UI.ListarAtivos();
                break;
            case 5:
                UI.ListarAprovados();
                break;
            case 6:
                UI.ListarReprovados();
                break;
            case 7:
                Console.WriteLine("\nPrograma encerrado!");
                break;
            default:
                Console.WriteLine("\nOpção inválida!");
                break;
        }
        
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
        menu = 0;
    }
    UI.Pause();
} while (menu != 7);
