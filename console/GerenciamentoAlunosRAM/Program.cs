using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoAlunosRAM
{
    internal class Program
    {

        private const int MAX_ALUNO = 100;

        private static int CUR_ALUNO = 0;
        public static void menu()
        {
            Console.Write(
@"##### MENU - Aluno #####
    1- Cadastrar
    2- Remover
    3- Buscar por CPF
    4- Listar todos
    5- Listar Aprovados
    6- Listar Reprovados
    7- Encerrar
        Opção: "
            );
        }

        public static bool validarCPF(string[][] matriz, string cpf)
        {
            for(int i = 0; i < CUR_ALUNO; i++){
                if(matriz[i][2] == cpf){
                    return false;
                }
            }
            return true;
        }

        public static void cadastrar(string[][] matriz)
        {
            //Console.ReadLine();
            string nome, dt_nascimento, cpf, media;
            Console.Write("\n##### Cadastrar Aluno #####\n");
            Console.Write("\tCPF: ");
            cpf = Console.ReadLine();
            if(validarCPF(matriz, cpf)){
                Console.Write("\tNome: ");
                nome = Console.ReadLine();
                Console.Write("\tData de Nascimento: ");
                dt_nascimento = Console.ReadLine();
                Console.Write("\tMédia: ");
                media = Console.ReadLine();

                matriz[CUR_ALUNO][0] = nome;
                matriz[CUR_ALUNO][1] = dt_nascimento;
                matriz[CUR_ALUNO][2] = cpf;
                matriz[CUR_ALUNO][3] = media;
                matriz[CUR_ALUNO][4] = "true";

                CUR_ALUNO++;

                //Console.Write("Aluno " + nome + " cadastrado com sucesso.\n");
                Console.Write($"Aluno {nome} cadastrado com sucesso.\n");
            }
            else{
                Console.Write("\nCPF já existente.\n");
            }
        }

        public static int buscaCPF(string[][] matriz, string cpf)
        {
            for(int i = 0; i < CUR_ALUNO; i++){
                if(matriz[i][2] == cpf){
                    return i;
                }
            }
            return -1;
        }

        public static void remover(string[][] matriz)
        {
            string cpf;
            int indice;

            Console.Write("\n##### Remover Aluno #####\n");
            Console.Write("\tCPF: ");

            cpf = Console.ReadLine();
            indice = buscaCPF(matriz, cpf);

            if (indice != -1) {
                matriz[indice][4] = "false";
                //Console.Write("Aluno " + matriz[indice][0] + " removido.");
                Console.Write($"Aluno {matriz[indice][0]} removido.\n");
            }
            else {
                //Console.Write("Aluno com CPF " + cpf + " não encontrado.");
                Console.Write($"Aluno com CPF {cpf} não encontrado.");
            }
        }

        public static void listar(string[][] matriz, int indice)
        {
            Console.Write("\n\n\tNome: " + matriz[indice][0]);
            Console.Write("\n\tData de Nascimento: " + matriz[indice][1]);
            Console.Write("\n\tCPF: " + matriz[indice][2]);
            Console.WriteLine("\n\tMédia: " + matriz[indice][3]);
        }

        public static void buscarAluno(string[][] matriz)
        {
            string cpf;
            int indice;

            Console.Write("\n##### Buscar Aluno #####\n");
            Console.Write("\tCPF: ");
    
            cpf = Console.ReadLine();

            indice = buscaCPF(matriz, cpf);

            if (indice != -1) {
                listar(matriz, indice);
            }
            else {
                //Console.Write("Aluno com CPF " + cpf + " não encontrado.");
                Console.WriteLine($"Aluno com CPF {cpf} não encontrado.");
            }
        }

        public static void listarTodos(string[][] matriz)
        {
            Console.Write("\n##### Alunos #####\n");
    
            for(int i = 0; i < CUR_ALUNO; i++){
                if(bool.Parse(matriz[i][4])){
                    listar(matriz, i);
                }
            }
        }

        public static void listarAprovados(string[][] matriz)
        {
            Console.Write("\n##### Alunos Aprovados #####\n");
    
            for(int i = 0; i < CUR_ALUNO; i++){
                if(bool.Parse(matriz[i][4]) && Convert.ToInt32(matriz[i][3]) >= 7){
                    listar(matriz, i);
                }
            }
        }

        public static void listarReprovados(string[][] matriz)
        {
            Console.Write("\n##### Alunos Reprovados #####\n");
    
            for(int i = 0; i < CUR_ALUNO; i++){
                if(bool.Parse(matriz[i][4]) && Convert.ToInt32(matriz[i][3]) < 7){
                    listar(matriz, i);
                }
            }
        }

        static void Main(string[] args)
        {
            string[][] alunos = new string[100][];

            for(int i = 0; i < 5; i++)
            {
                alunos[i] = new string[5];
            }

            char opcao;

            do {
                menu();

                opcao = (char)Console.Read();
                Console.ReadLine();

                switch (opcao)
                {
                    case '1':
                        cadastrar(alunos);
                        break;
                    case '2':
                        remover(alunos);

                        break;
                    case '3':
                        buscarAluno(alunos);

                        break;
                    case '4':
                        listarTodos(alunos);

                        break;
                    case '5':
                        listarAprovados(alunos);

                        break;
                    case '6':
                        listarReprovados(alunos);
                        break;
                    case '7':
                        Console.Write("\n\tFIM !!\n");
                        break;
                    default:
                        Console.Write("Opção Inválida.\n\n");
                        break;
                }
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            } while (opcao != '7');

            Console.Write("Obrigado por utilizar o sistema!!");
        }
    }
}
