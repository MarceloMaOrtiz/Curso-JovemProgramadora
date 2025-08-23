using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Services.Dto;

namespace ConsoleUI.UI
{
    public static class UIAluno
    {

        public static void TestarConexao()
        {
            if (ServicesAluno.TestarConexao())
            {
                Console.WriteLine("Conectado");
            }
            else
            {
                Console.WriteLine("Desconectado");
            }
        }
        public static void CadastroAluno()
        {
            string cpf, nome;
            double media;
            DateOnly dt_nascimento;

            Console.WriteLine("Preencha as informações a seguir:\nCPF: ");
            cpf = Console.ReadLine();

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

            if (!ServicesAluno.ExisteCpf(cpf))
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();

                Console.WriteLine("Data de nascimento:");
                dt_nascimento = DateOnly.Parse(Console.ReadLine());

                Console.WriteLine("Média:");
                media = Convert.ToDouble(Console.ReadLine());

                AlunoDto dto = new AlunoDto
                {
                    Nome = nome,
                    Cpf = cpf,
                    DataNascimento = dt_nascimento,
                    Media = media,
                    Ativo = true
                };

                ServicesAluno.CadastrarAluno(dto);
            }
        }

        public static void ListarAtivos()
        {
            
            (List<AlunoDto> alunos, bool sucesso, string mensagem) = ServicesAluno.ListarAlunos();

            if (!sucesso)
            {
                Console.WriteLine($"Erro ao listar alunos: {mensagem}");
            }

            if (alunos.Count == 0)
            {
                Console.WriteLine("Nenhum aluno ativo encontrado.");
            }
            else
            {
                Console.WriteLine("\nLista de Alunos Ativos:");
                foreach (AlunoDto dto in alunos)
                {
                    Console.WriteLine($"Nome: {dto.Nome} - Data de nascimento: {dto.DataNascimento} - CPF: {dto.Cpf} - Média: {dto.Media}");
                }
            }
            
        }
    }
}
