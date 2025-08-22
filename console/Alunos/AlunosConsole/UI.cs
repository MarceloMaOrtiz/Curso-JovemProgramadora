
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

        public static void TestarConexao()
        {
            RespostaServico<object> resposta = Services.TestarConexao();
            Console.WriteLine(resposta.Mensagem);
            Console.WriteLine(resposta.Sucesso);
        }

        public static void LimpaTela()
        {
            Console.Clear();
        }

        public static void CadastrarAluno()
        {
            string cpf, nome;
            DateOnly dt_nascimento;
            double media;

            do
            {
                Console.Write("Preencha as informações a seguir:\nCPF: ");
                cpf = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrWhiteSpace(cpf));

            if (!Services.ExisteCpf(cpf))
            {

                Console.Write("Nome: ");
                nome = Console.ReadLine() ?? string.Empty;

                Console.Write("Data de Nascimento: ");
                dt_nascimento = DateOnly.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Média: ");
                media = Convert.ToDouble(Console.ReadLine());

                AlunoDto dtoNovoAluno = new AlunoDto
                {
                    Nome = nome,
                    DataNascimento = dt_nascimento,
                    Cpf = cpf,
                    Media = media
                };

                RespostaServico<AlunoDto> resposta = Services.CadastrarAluno(dtoNovoAluno);
                Console.WriteLine(resposta.Mensagem);
            }
            else
            {
                Console.WriteLine($"CPF {cpf} já cadastrado");
                AtivarAluno(cpf);
            }

        }

        public static void AtivarAluno(string cpf)
        {

            try
            {
                RespostaServico<AlunoDto> resposta = Services.BuscarAlunoCpf(cpf);
                if (resposta?.Objeto != null && !resposta.Objeto.Ativo)
                {
                    int opcao;
                    Console.WriteLine("Aluno desativado, deseja reativar?\n1 - Sim\n2 - Não\nOpção: ");
                    opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            resposta = Services.AtivarAluno(resposta.Objeto);
                            if (resposta.Sucesso)
                                Console.WriteLine($"Aluno {resposta.Objeto?.Nome} reativado com sucesso!\n");
                            else
                                Console.WriteLine($"Erro ao reativar aluno: {resposta.Mensagem}");
                            break;
                        case 2:
                            Console.WriteLine($"Aluno {resposta.Objeto.Nome} segue desativado!\n");
                            break;
                        default:
                            Console.WriteLine("Opção inválida, retornando para o menu inicial.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Aluno com CPF {cpf} não encontrado ou já está ativo.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao reativar aluno: {ex.Message}");
            }

        }

        public static void ListarAtivos()
        {
            (List<AlunoDto> alunos, bool sucesso, string msg) = Services.ListarAtivos();

            if (sucesso)
            {
                if (alunos.Count == 0)
                {
                    Console.WriteLine("\nNão existem alunos cadastrados!\n");
                }
                else
                {
                    Console.WriteLine("\nAlunos Ativos:\n");
                    foreach (var aluno in alunos)
                    {
                        Console.WriteLine($"Nome: {aluno.Nome} | Data de Nascimento: {aluno.DataNascimento.ToString("dd/MM/yyyy")} | CPF: {aluno.Cpf} | Média: {aluno.Media}");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"Erro ao listar alunos ativos: {msg}");
            }
        }

        public static void RemoverAluno()
        {
            string cpf;
            Console.Write("Informe o CPF do aluno a ser removido: ");
            cpf = Console.ReadLine() ?? string.Empty;
            RespostaServico<AlunoDto> resposta = Services.BuscarAlunoCpf(cpf);
            if (resposta.Objeto != null)
            {
                // RespostaServico resposta = Services.RemoverAluno(aluno);
                resposta = Services.RemoverAluno(resposta.Objeto);
                if (resposta.Sucesso)
                {
                    Console.WriteLine($"Aluno {resposta.Objeto?.Nome} desativado com sucesso!\n");
                }
                else
                {
                    Console.WriteLine($"Erro ao desativar aluno: {resposta.Mensagem}");
                }
            }
            else
            {
                Console.WriteLine($"Aluno com CPF {cpf} não encontrado.");
            }
        }
    }
}
