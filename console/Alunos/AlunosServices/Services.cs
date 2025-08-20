using AlunosModels;
using AlunosRepository;
using AlunosServices.DTO;
using AlunosServices.Serializers;

namespace AlunosServices
{
    public static class Services
    {
        public static List<AlunoDto> alunos = new List<AlunoDto>();

        public static bool ExisteCpf(string cpf)
        {
            // Aqui você pode implementar a lógica de verificação de CPF
            // Por exemplo, consultar um repositório ou banco de dados
            return Repository.ExisteCpf(cpf);
        }

        public static (CreateAlunoDto, bool) CadastrarAluno(CreateAlunoDto aluno)
        {
            Aluno novoAluno = Serializer.CreateDtoToAluno(aluno);
            (novoAluno, bool sucesso) = Repository.CadastrarAluno(novoAluno);

            if (sucesso)
            {
                alunos.Add(Serializer.AlunoToDto(novoAluno));
            }

            return (Serializer.AlunoToCreateDto(novoAluno), sucesso);
        }

        public static List<AlunoDto> ListarAtivos()
        {
            List<AlunoDto> alunosAtivos = new List<AlunoDto>();
            foreach (var aluno in alunos)
            {
                if (aluno.Ativo)
                {
                    alunosAtivos.Add(aluno);
                }
            }
            return alunosAtivos;
        }
    }
}
