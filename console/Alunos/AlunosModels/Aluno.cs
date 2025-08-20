namespace AlunosModels
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; } = "";

        public DateOnly DataNascimento { get; set; }

        public string Cpf { get; set; } = "";

        public double Media { get; set; }

        public bool Ativo { get; set; }

        public Aluno() { }

        public Aluno(string nome, DateOnly dataNascimento, string cpf, double media)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Media = media;
            Ativo = true;
        }
    }
}
