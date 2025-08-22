using AlunosModels;
using AlunosRepository;
using AlunosServices.DTO;
using AlunosServices.Serializers;
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace AlunosServices
{
    public static class Services
    {

        public static RespostaServico<object> TestarConexao()
        {

            string msg;
            bool sucesso;

            (sucesso, msg) = Repository.TestarConexao();
            return new RespostaServico<object>
            {
                Objeto = null,
                Sucesso = sucesso,
                Mensagem = msg
            };
        }

        public static bool ExisteCpf(string cpf)
        {
            // Aqui você pode implementar a lógica de verificação de CPF
            // Por exemplo, consultar um repositório ou banco de dados
            return Repository.ExisteCpf(cpf);
        }

        public static RespostaServico<AlunoDto> CadastrarAluno(AlunoDto dto)
        {
            Aluno novoAluno = Serializer.DtoToAluno(dto);
            (novoAluno, bool sucesso, string msg) = Repository.CadastrarAluno(novoAluno);

            return new RespostaServico<AlunoDto>
            { 
                Objeto = Serializer.AlunoToDto(novoAluno),
                Sucesso = sucesso,
                Mensagem = msg
            };
        }

        public static RespostaServico<AlunoDto> AtualizarAluno(AlunoDto dto)
        {
            {
                Aluno alunoAtualizado = Serializer.DtoToAluno(dto);
                (_, bool sucesso, string msg) = Repository.AtualizarAluno(alunoAtualizado);

                return new RespostaServico<AlunoDto>
                {
                    Objeto = Serializer.AlunoToDto(alunoAtualizado),
                    Sucesso = sucesso,
                    Mensagem = msg
                };
            }
        }

        public static (List<AlunoDto>, bool, string) ListarAtivos()
        {

            (List<Aluno> alunos, bool sucesso, string msg) = Repository.ListarAtivos();


            List<AlunoDto> dtoAlunos = new List<AlunoDto>();
            foreach (var aluno in alunos)
            {
                if (aluno.Ativo)
                {
                    dtoAlunos.Add(Serializer.AlunoToDto(aluno));
                }
            }
            return (dtoAlunos, sucesso, msg);
        }

        public static RespostaServico<AlunoDto> BuscarAlunoCpf(string cpf)
        {
            (Aluno? aluno, bool sucesso, string msg) = Repository.BuscarAlunoCpf(cpf);

            if (aluno == null)
            {
                return new RespostaServico<AlunoDto>
                {
                    Objeto = null,
                    Sucesso = false,
                    Mensagem = "Aluno não encontrado."
                };
            }

            return new RespostaServico<AlunoDto>()
            {
                Objeto = Serializer.AlunoToDto(aluno),
                Sucesso = sucesso,
                Mensagem = "Aluno não encontrado."
            };
        }


        public static RespostaServico<AlunoDto> RemoverAluno(AlunoDto dto)
        {            
            dto.Ativo = false;

            return AtualizarAluno(dto);
        }

        public static RespostaServico<AlunoDto> AtivarAluno(AlunoDto dto)
        {
            dto.Ativo = true;
            return AtualizarAluno(dto);
        }
    }
}
