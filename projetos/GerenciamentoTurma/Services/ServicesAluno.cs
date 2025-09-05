using Models;
using Repository;
using Services.Dto;
using Services.Dto.Serializers;

namespace Services
{
    public static class ServicesAluno
    {
        public static bool TestarConexao()
        {
            return RepositoryAluno.TestarConexao();
        }

        public static RespostaServico<bool> ExisteCpf(string cpf)
        {
            (bool existe, bool sucesso, string mensagem) = RepositoryAluno.ExisteCpf(cpf);

            return new RespostaServico<bool>(existe, sucesso, mensagem);
        }

        public static RespostaServico<AlunoDto?> BuscarAlunoCpf(string cpf)
        {
            (Aluno? aluno, bool sucesso, string mensagem) = RepositoryAluno.BuscarAlunoCpf(cpf);
            
            if(aluno == null)
            {
                return new RespostaServico<AlunoDto?>(null, sucesso, mensagem);
            }
            return new RespostaServico<AlunoDto?>(AlunoSerializer.AlunoToDto(aluno), sucesso, mensagem);
        }

        public static RespostaServico<AlunoDto> DesativarAluno(AlunoDto alunoDto)
        {
            alunoDto.Ativo = false;
            return AtualizarAluno(alunoDto);
        }

        public static RespostaServico<AlunoDto> CadastrarAluno(AlunoDto dto)
        {
            Aluno aluno = AlunoSerializer.DtoToAluno(dto);


            (aluno, bool sucesso, string mensagem) = RepositoryAluno.CadastrarAluno(aluno);

            return new RespostaServico<AlunoDto>(AlunoSerializer.AlunoToDto(aluno), sucesso, mensagem);
        }

        public static RespostaServico<AlunoDto> AtualizarAluno(AlunoDto dto)
        {
            Aluno aluno = AlunoSerializer.DtoToAluno(dto);

            (aluno, bool sucesso, string mensagem) = RepositoryAluno.AtualizarAluno(aluno);

            return new RespostaServico<AlunoDto>(AlunoSerializer.AlunoToDto(aluno), sucesso, mensagem);
        }

        public static RespostaServico<AlunoDto> AtivarAluno(AlunoDto alunoDto)
        {
            alunoDto.Ativo = true;
            return AtualizarAluno(alunoDto);
        }

        public static RespostaServico<List<AlunoDto>> ListarAlunos()
        {
            (List<Aluno> listaAlunos, bool sucesso, string mensagem) = RepositoryAluno.ListarAlunos();

            return new RespostaServico<List<AlunoDto>>(AlunoSerializer.AlunosToDtos(listaAlunos), sucesso, mensagem);
        }

        public static RespostaServico<List<AlunoDto>> ListarAprovados()
        {
            (List<Aluno> listaAlunos, bool sucesso, string mensagem) = RepositoryAluno.ListarAlunos();

            List<Aluno> aprovados = listaAlunos.Where(aluno => aluno.Media >= 7 && aluno.Ativo).ToList();

            return new RespostaServico<List<AlunoDto>>(AlunoSerializer.AlunosToDtos(aprovados), sucesso, mensagem);
        }

        public static RespostaServico<List<AlunoDto>> ListarReprovados()
        {
            (List<Aluno> listaAlunos, bool sucesso, string mensagem) = RepositoryAluno.ListarAlunos();

            List<Aluno> aprovados = listaAlunos.Where(aluno => aluno.Media < 7 && aluno.Ativo).ToList();

            return new RespostaServico<List<AlunoDto>>(AlunoSerializer.AlunosToDtos(aprovados), sucesso, mensagem);
        }
    }
}
