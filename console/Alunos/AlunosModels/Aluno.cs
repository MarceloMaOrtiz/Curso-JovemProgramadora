using AlunosModels.ValueObject;

namespace AlunosModels
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; } = "";

        public required DataNascimento DtNascimento { get; set; }

        public required Cpf Cpf { get; set; }

        public double Media { get; set; }

        public bool Ativo { get; set; }

        public Aluno() { }

        public Aluno(string nome, DateOnly dataNascimento, string cpf, double media)
        {
            Nome = nome;
            DtNascimento = new DataNascimento(dataNascimento);
            Cpf = new Cpf(cpf);
            Media = media;
            Ativo = true;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} | Data de Nascimento: {DtNascimento.Valor.ToString("dd/MM/yyyy")} | CPF: {Cpf} | Média: {Media}";
        }
    }
}
