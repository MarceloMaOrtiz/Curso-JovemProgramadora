using Models;
using Repository;
using Services.Dto;
using Services.Dto.Serializers;

namespace Services
{
    public static class ServicesAluno
    {
        public static List<AlunoDto> listaAlunos = new List<AlunoDto>();

        public static bool ListaVazia()
        {
            if (listaAlunos.Count == 0)
            {
                return true;
            }
            return false;
        }

        public static bool ExisteCpf(string cpf)
        {
            return RepositoryAluno.ExisteCpf(cpf);
        }

        public static AlunoDto CadastrarAluno(AlunoDto dto)
        {
            Aluno aluno = AlunoSerializer.DtoToAluno(dto);

            listaAlunos.Add(dto);

            return dto;

            //return RepositoryAluno.CadastrarAluno(aluno);

        }

        public static List<AlunoDto> ListarAlunos()
        {
            // TODO: Implementar a lógica para listar alunos ativos no BD.

            return listaAlunos;
        }
    }
}
