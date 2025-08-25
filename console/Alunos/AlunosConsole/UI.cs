
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
            RespostaServico<bool> resposta = Services.TestarConexao();
            Console.WriteLine(resposta.Mensagem);
            Console.WriteLine(resposta.Objeto);
        }

        public static void LimpaTela()
        {
            Console.Clear();
        }

        public static void Pause()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadLine();
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

            if (!Services.ExisteCpf(cpf).Objeto)
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
            RespostaServico<List<AlunoDto>> resposta = Services.ListarAtivos();

            if (resposta.Sucesso && resposta.Objeto != null)
            {
                if (resposta.Objeto.Count == 0)
                {
                    Console.WriteLine("\nNão existem alunos cadastrados!\n");
                }
                else
                {
                    Console.WriteLine("\nAlunos Ativos:\n");
                    Listar(resposta.Objeto);
                }
            }
            else
            {
                Console.WriteLine($"Erro ao listar alunos ativos: {resposta.Mensagem}");
            }
        }

        public static void BuscarAlunoCpf()
        {
            string cpf;
            Console.Write("Informe o CPF do aluno a ser buscado: ");
            cpf = Console.ReadLine() ?? string.Empty;
            RespostaServico<AlunoDto> resposta = Services.BuscarAlunoCpf(cpf);
            if (resposta.Sucesso)
            {
                if (resposta.Objeto != null)
                {
                    AlunoDto aluno = resposta.Objeto;
                    Console.WriteLine($"\nAluno encontrado:\n{aluno}\n");
                }
                else
                {
                    Console.WriteLine($"Aluno com CPF {cpf} não encontrado.");
                }
            }
            else
            {
                Console.WriteLine($"Erro ao buscar aluno: {resposta.Mensagem}");
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

        public static void ListarAprovados()
        {
            RespostaServico<List<AlunoDto>> resposta = Services.ListarAprovados();
            if (resposta.Sucesso && resposta.Objeto != null)
            {
                if (resposta.Objeto.Count == 0)
                {
                    Console.WriteLine("\nNão existem alunos aprovados!\n");
                }
                else
                {
                    Console.WriteLine("\nAlunos Aprovados:\n");
                    Listar(resposta.Objeto);
                }
            }
            else
            {
                Console.WriteLine($"Erro ao listar alunos aprovados: {resposta.Mensagem}");
            }
        }

        public static void ListarReprovados()
        {
            RespostaServico<List<AlunoDto>> resposta = Services.ListarReprovados();
            if (resposta.Sucesso && resposta.Objeto != null)
            {
                if (resposta.Objeto.Count == 0)
                {
                    Console.WriteLine("\nNão existem alunos reprovados!\n");
                }
                else
                {
                    Console.WriteLine("\nAlunos Reprovados:\n");
                    Listar(resposta.Objeto);
                }
            }
            else
            {
                Console.WriteLine($"Erro ao listar alunos reprovados: {resposta.Mensagem}");
            }
        }

        public static void Listar(List<AlunoDto> alunosDto)
        {
            foreach (var aluno in alunosDto)
            {
                Console.WriteLine(aluno.ToString());
            }
            Console.WriteLine();
        }
    }
}
