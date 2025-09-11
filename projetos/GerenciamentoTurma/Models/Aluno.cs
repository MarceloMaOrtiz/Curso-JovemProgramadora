using Models.ValueObjects;

namespace Models
{
    public class Aluno
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required DataNascimento DataNascimento { get; set; }

        public required Cpf Cpf { get; set; }

        public double Media { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
