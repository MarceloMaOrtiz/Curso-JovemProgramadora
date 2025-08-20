using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciamento_de_turma
{
    internal class Program
    {
        static int cadastro = 0;

        public static bool ValidaCadastro(){
            if (cadastro == 0){
                Console.WriteLine("\nNão existem alunos cadastrados!");
                return false;
            }
            return true;    
        }

        public static void CadastroAluno(string[,] matriz)
        {
            bool fazerCadastro = true;
            string cpf;

            Console.WriteLine("Preencha as informações a seguir:\nCPF: ");
            cpf = Console.ReadLine();

            for (int i = 0; i < cadastro; i++){
                if(matriz[i,2] == cpf){
                    Console.WriteLine("\nO CPF informado já existe!\n");
                    fazerCadastro = false;
                    if(!Convert.ToBoolean(matriz[i,4])){
                        int opcao;
                        Console.WriteLine("Aluno desativado, deseja reativar?\n1 - Sim\n2 - Não\nOpção: ");
                        opcao = Convert.ToInt32(Console.ReadLine());
                        switch (opcao) {
                            case 1:
                                matriz[i, 4] = "true";
                                Console.WriteLine($"Aluno {matriz[i, 0]} reativado com sucesso!\n");
                            break;
                            case 2:
                                Console.WriteLine($"Aluno {matriz[i, 0]} segue desativado!\n");
                            break;
                            default:
                                Console.WriteLine("Opção inválida, retornando para o menu inicial.");
                            break;
                        }
                        i = cadastro;
                    }
                }
            }

            if(fazerCadastro){
                cpf = matriz[cadastro, 2];

                Console.WriteLine("Nome:");
                matriz[cadastro,0] = Console.ReadLine();

                Console.WriteLine("Data de nascimento:");
                matriz[cadastro, 1] = Console.ReadLine();

                Console.WriteLine("Média:");
                matriz[cadastro, 3] = Console.ReadLine();

                matriz[cadastro, 4] = "true";

                Console.WriteLine($"Aluno {matriz[cadastro,0]} cadastrado com sucesso!\n");

                cadastro++;
            }

        }
        
        public static void ListarAtivos(string[,] matriz)
        {
            if(ValidaCadastro()){
                for(int i = 0; i < cadastro; i++){
                    if (Convert.ToBoolean(matriz[i, 4])){
                        Console.WriteLine($"\nNome: {matriz[i,0]} \nData de nascimento: {matriz[i,1]}");
                        Console.WriteLine($"CPF: {matriz[i,2]} \nMédia: {matriz[i,3]}");
                    }
                }
            }
        }

        public static void RemoverAluno(string[,] matriz){
            string cpf;
                if(ValidaCadastro()){
                Console.WriteLine("\nInsira o CPF do aluno que você deseja remover: ");
                cpf = Console.ReadLine();
                for(int i = 0; i < cadastro; i++){
                    if(matriz[i,2] == cpf){
                        matriz[i, 4] = "false";
                        i = cadastro;
                    }
                }
                Console.WriteLine("\nAluno removido com sucesso!");
            }
        }

        public static void BuscarAluno(string[,] matriz){
            string cpf;
            if (ValidaCadastro()){
                Console.WriteLine("\nInsira o CPF do aluno que você deseja encontrar: ");
                cpf = Console.ReadLine();
    
                for (int i = 0; i < cadastro; i++){
                    if (Convert.ToBoolean(matriz[i, 4]) == false){
                        Console.WriteLine("Aluno está desativado");
                    }
                    else if(matriz[i,2] == cpf){
                        Console.WriteLine($"\nNome: {matriz[i, 0]} \nData de nascimento: {matriz[i, 1]}");
                        Console.WriteLine($"CPF: {matriz[i, 2]} \nMédia: {matriz[i, 3]}");
                        i = cadastro;
                    }  
                }
            }
        }

        public static void Media(string[,] matriz, int opcao){
            if(ValidaCadastro()){
                if(opcao == 5){
                    Console.WriteLine("\nAlunos aprovados: ");
                    for(int i = 0; i < cadastro; i++){
                        if (Convert.ToInt32(matriz[i,3]) >= 7 && Convert.ToBoolean(matriz[i, 4])){
                            Console.WriteLine($"\n {matriz[i,0]}");
                        }
                    }
                }
                else{
                    Console.WriteLine("\nAlunos reprovados: ");
                    for (int i = 0; i < cadastro; i++){
                        if (Convert.ToInt32(matriz[i, 3]) < 7 && Convert.ToBoolean(matriz[i, 4])){
                            Console.WriteLine($"\n {matriz[i, 0]}");
                        }
                    }
                }
            }
        }
        static void Main(){
            string[,] matriz = new string[100, 5];
            int menu;

            do{
                Console.WriteLine("\n\n Menu Principal:\n1 - Cadastrar aluno\n2 - Remover Aluno\n3 - Buscar Aluno\n4 - Listar todos os Alunos\n5 - Listar Alunos Aprovados\n6 - Listar Alunos Reprovados\n7 - Sair\nOpção: ");
                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu){
                    case 1:
                        CadastroAluno(matriz);
                    break;
                    case 2:
                        RemoverAluno(matriz);
                    break;
                    case 3:
                        BuscarAluno(matriz);
                    break;
                    case 4:
                        ListarAtivos(matriz);
                    break;
                    case 5:
                        Media(matriz, 5);
                    break;
                    case 6:
                        Media(matriz, 6);
                    break;
                    case 7:
                        Console.WriteLine("\nPrograma encerrado!");
                    break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                    break;
                }
            } while (menu != 7 && cadastro < 100);
        }
    }
}
