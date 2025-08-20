
using AlunosServices;
using AlunosServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunosConsole
{
    public static class UI
    {
        public static void LimpaTela()
        {
            Console.Clear();
        }

        public static (CreateAlunoDto, string) CadastrarAluno()
        {
            string cpf, nome;
            DateOnly dt_nascimento;
            double media;

            do
            {
                Console.Write("Preencha as informações a seguir:\nCPF: ");
                cpf = Console.ReadLine();
            }while (string.IsNullOrWhiteSpace(cpf));

            //for (int i = 0; i < cadastro; i++)
            //{
            //    if (matriz[i, 2] == cpf)
            //    {
            //        Console.WriteLine("\nO CPF informado já existe!\n");
            //        fazerCadastro = false;
            //        if (!Convert.ToBoolean(matriz[i, 4]))
            //        {
            //            int opcao;
            //            Console.WriteLine("Aluno desativado, deseja reativar?\n1 - Sim\n2 - Não\nOpção: ");
            //            opcao = Convert.ToInt32(Console.ReadLine());
            //            switch (opcao)
            //            {
            //                case 1:
            //                    matriz[i, 4] = "true";
            //                    Console.WriteLine($"Aluno {matriz[i, 0]} reativado com sucesso!\n");
            //                    break;
            //                case 2:
            //                    Console.WriteLine($"Aluno {matriz[i, 0]} segue desativado!\n");
            //                    break;
            //                default:
            //                    Console.WriteLine("Opção inválida, retornando para o menu inicial.");
            //                    break;
            //            }
            //            i = cadastro;
            //        }
            //    }
            //}

            if (!Services.ExisteCpf(cpf))
            {

                Console.Write("Nome:");
                nome = Console.ReadLine();

                Console.Write("Data de nascimento:");
                dt_nascimento = DateOnly.Parse(Console.ReadLine());

                Console.Write("Média:");
                media = Convert.ToDouble(Console.ReadLine());

                CreateAlunoDto dtoNovoAluno = new CreateAlunoDto
                {
                    Nome = nome,
                    DataNascimento = dt_nascimento,
                    Cpf = cpf,
                    Media = media
                };

                (CreateAlunoDto dtoAluno, bool sucesso) = Services.CadastrarAluno(dtoNovoAluno);

                if (sucesso)
                {
                    return (dtoAluno, "Cadastro realizado com sucesso!");
                }
                else
                {
                    return (dtoAluno, "Erro ao cadastrar aluno.");
                }
            }
            else {
                return (new CreateAlunoDto(), "CPF já cadastrado");
            }
                
        }

        public static void ListarAtivos()
        {
            List<AlunoDto> alunos = Services.ListarAtivos();

            if (alunos.Count == 0)
            {
                Console.WriteLine("\nNão existem alunos cadastrados!\n");
            }
            else
            {
                Console.WriteLine("\nAlunos Ativos:\n");
                foreach (var aluno in alunos)
                {
                    Console.WriteLine($"Nome: {aluno.Nome} | Data de Nascimento: {aluno.DataNascimento.ToString("dd/MM/yyyy")} | CPF: {aluno.Cpf} | Média: {aluno.Media} | Ativo: {aluno.Ativo}");
                }
                Console.WriteLine();
            }
        }
    }
}
