using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ValueObjects;
using Services;
using Services.Dto;

namespace ConsoleUI.UI
{
    public static class UIAluno
    {
        public static void LimparTela()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

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

        public static void RemoverAluno()
        {
            Cpf cpf;

            try {
                Console.Write("Informe o CPF do aluno a ser removido: ");
                cpf = new Cpf(Console.ReadLine() ?? "");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"CPF inválido: {ex.Message}");
                return;
            }
            

            RespostaServico<AlunoDto?> resposta = ServicesAluno.BuscarAlunoCpf(cpf);

            if (!resposta.Sucesso)
            {
                Console.WriteLine($"Erro ao buscar aluno: {resposta.Mensagem}");
                return;
            }
            if (resposta.Objeto == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            if (!resposta.Objeto.Ativo)
            {
                Console.WriteLine("Aluno já está desativado.");
                return;
            }

            RespostaServico<AlunoDto> respostaDesativacao = ServicesAluno.DesativarAluno(resposta.Objeto);

            if (!respostaDesativacao.Sucesso || respostaDesativacao.Objeto == null)
            {
                Console.WriteLine($"Erro ao desativar aluno: {respostaDesativacao.Mensagem}");
                return;
            }

            Console.WriteLine($"Aluno {respostaDesativacao.Objeto.Nome} desativado com sucesso.");

        }

        public static void CadastroAluno()
        {
            string nome;
            Cpf cpf;
            double media;
            DataNascimento? dt_nascimento;

            try
            {
                Console.Write("Preencha as informações a seguir:\nCPF: ");
                cpf = new Cpf(Console.ReadLine() ?? "");

                RespostaServico<bool> resposta = ServicesAluno.ExisteCpf(cpf);

                if (!resposta.Sucesso)
                {
                    Console.WriteLine($"Erro ao verificar CPF: {resposta.Mensagem}");
                    return;
                }

                if (!resposta.Objeto)
                {

                    Console.Write("Nome: ");
                    nome = Console.ReadLine() ?? "";

                    Console.Write("Data de nascimento: ");
                    dt_nascimento = new DataNascimento(DateOnly.Parse(Console.ReadLine() ?? ""));
                      
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
            catch(ArgumentException e) {
                Console.WriteLine(e.Message);
                return;
            }  
        }

        public static void ReativarAluno(Cpf cpf)
        {
            RespostaServico<AlunoDto?> respostaBusca = ServicesAluno.BuscarAlunoCpf(cpf);

            if (!respostaBusca.Sucesso)
            {
                Console.WriteLine($"Erro: {respostaBusca.Mensagem}");
            }
            if (respostaBusca.Objeto != null)
            {
                if (respostaBusca.Objeto.Ativo)
                {
                    Console.WriteLine("\nO CPF informado já está ativado!\n");
                }
                else
                {
                    int opcao;
                    Console.Write("Aluno desativado, deseja reativar?\n1 - Sim\n2 - Não\nOpção: ");
                    opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            RespostaServico<AlunoDto> respostaAtivacao = ServicesAluno.AtivarAluno(respostaBusca.Objeto);
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

        public static void BuscarAluno()
        {
            Cpf cpf;

            try
            {
                Console.Write("Informe o CPF do aluno a ser buscado: ");
                cpf = new Cpf(Console.ReadLine() ?? "");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"CPF inválido: {ex.Message}");
                return;
            }

            RespostaServico<AlunoDto?> resposta = ServicesAluno.BuscarAlunoCpf(cpf);

            if (!resposta.Sucesso)
            {
                Console.WriteLine($"Erro ao buscar aluno: {resposta.Mensagem}");
                return;
            }
            if(resposta.Objeto == null) {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            AlunoDto dto = resposta.Objeto;
            Console.WriteLine($"{dto} - Ativo: {(dto.Ativo ? "Sim" : "Não")}");
        }

        public static void ListarAprovados()
        {
            RespostaServico<List<AlunoDto>> resposta = ServicesAluno.ListarAprovados();

            if (!resposta.Sucesso)
            {
                Console.WriteLine($"Erro ao listar alunos: {resposta.Mensagem}");
            }

            if ((resposta.Objeto != null && resposta.Objeto.Count == 0) || resposta.Objeto == null)
            {
                Console.WriteLine("Nenhum aluno aprovado.");
            }
            else
            {
                foreach (AlunoDto dto in resposta.Objeto)
                {
                    Console.WriteLine(dto);
                }
            }
        }

        public static void ListarReprovados()
        {
            RespostaServico<List<AlunoDto>> resposta = ServicesAluno.ListarReprovados();

            if (!resposta.Sucesso)
            {
                Console.WriteLine($"Erro ao listar alunos: {resposta.Mensagem}");
            }

            if ((resposta.Objeto != null && resposta.Objeto.Count == 0) || resposta.Objeto == null)
            {
                Console.WriteLine("Nenhum aluno reprovado.");
            }
            else
            {
                foreach (AlunoDto dto in resposta.Objeto)
                {
                    Console.WriteLine(dto);
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
                    Console.WriteLine(dto);
                }
            }
            
        }
    }
}
