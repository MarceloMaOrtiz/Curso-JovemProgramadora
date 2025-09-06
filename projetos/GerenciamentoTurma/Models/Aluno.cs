using Models.ValueObjects;

namespace Models
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; } = "";

        public required DataNascimento DataNascimento { get; set; }

        public Cpf Cpf { get; set; } = new Cpf("");

        public double Media { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
