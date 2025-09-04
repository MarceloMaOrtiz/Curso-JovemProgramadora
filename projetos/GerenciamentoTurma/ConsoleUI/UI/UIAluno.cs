using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Console.Write("Preencha as informações a seguir:\nCPF: ");
            cpf = Console.ReadLine();

            RespostaServico<bool> resposta = ServicesAluno.ExisteCpf(cpf);

            if (!resposta.Sucesso)
            {
                Console.WriteLine($"Erro ao verificar CPF: {resposta.Mensagem}");
                return;
            }

            if (!resposta.Objeto)
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();

                Console.Write("Data de nascimento: ");
                dt_nascimento = DateOnly.Parse(Console.ReadLine());

                Console.Write("Média: ");
                media = Convert.ToDouble(Console.ReadLine());

                AlunoDto dto = new AlunoDto
                {
                    Nome = nome,
                    Cpf = cpf,
                    DataNascimento = dt_nascimento,
                    Media = media,
                    Ativo = true
                };

                //(dto, sucesso, mensagem) = ServicesAluno.CadastrarAluno(dto);
                RespostaServico<AlunoDto> respostaCadastro = ServicesAluno.CadastrarAluno(dto);

                if (respostaCadastro.Objeto != null && respostaCadastro.Sucesso)
                {
                    Console.WriteLine($"Aluno {respostaCadastro.Objeto.Nome} cadastrado com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Erro ao cadastrar aluno: {resposta.Mensagem}");
                }
            }
            else
            {
                ReativarAluno(cpf);                    
            }
        }

        public static void ReativarAluno(String cpf)
        {
            //(AlunoDto? dto, bool sucesso, string mensagem) = ServicesAluno.BuscarAlunoCpf(cpf);
            RespostaServico<AlunoDto> respostaBusca = ServicesAluno.BuscarAlunoCpf(cpf);

            if (!respostaBusca.Sucesso)
            {
                Console.WriteLine($"Erro: {respostaBusca.Mensagem}");
            }
            if (respostaBusca.Objeto != null)
            {
                if (respostaBusca.Objeto.Ativo)
                {
                    Console.WriteLine("\nO CPF informado já existe!\n");
                }
                else
                {
                    int opcao;
                    Console.Write("Aluno desativado, deseja reativar?\n1 - Sim\n2 - Não\nOpção: ");
                    opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            respostaBusca.Objeto.Ativo = true;
                            //(dto, sucesso, mensagem) = ServicesAluno.AtualizarAluno(dto);
                            RespostaServico<AlunoDto> respostaAtualizacao = ServicesAluno.AtualizarAluno(respostaBusca.Objeto);
                            Console.WriteLine($"Aluno {respostaBusca.Objeto.Nome} reativado com sucesso!\n");
                            break;
                        case 2:
                            Console.WriteLine($"Aluno {respostaBusca.Objeto.Nome} segue desativado!\n");
                            break;
                        default:
                            Console.WriteLine("Opção inválida, retornando para o menu inicial.");
                            break;
                    }
                }
            }
        }

        public static void ListarAtivos()
        {
            
            //(List<AlunoDto> alunos, bool sucesso, string mensagem) = ServicesAluno.ListarAlunos();
            RespostaServico<List<AlunoDto>> resposta = ServicesAluno.ListarAlunos();

            if (!resposta.Sucesso)
            {
                Console.WriteLine($"Erro ao listar alunos: {resposta.Mensagem}");
            }

            if ((resposta.Objeto != null && resposta.Objeto.Count == 0) || resposta.Objeto == null)
            {
                Console.WriteLine("Nenhum aluno ativo encontrado.");
            }
            else
            {
                Console.WriteLine("\nLista de Alunos Ativos:");
                foreach (AlunoDto dto in resposta.Objeto)
                {
                    Console.WriteLine($"Nome: {dto.Nome} - Data de nascimento: {dto.DataNascimento} - CPF: {dto.Cpf} - Média: {dto.Media}");
                }
            }
            
        }
    }
}
