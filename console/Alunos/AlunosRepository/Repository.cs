using AlunosModels;

namespace AlunosRepository
{
    public static class Repository
    {
        public static bool ExisteCpf(string cpf)
        {
            return false;
        }

        public static (Aluno, bool) CadastrarAluno(Aluno aluno)
        {
            return (aluno, true);
        }
    }
}
