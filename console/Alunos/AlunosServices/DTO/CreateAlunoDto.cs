using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunosServices.DTO
{
    public class CreateAlunoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public DateOnly DataNascimento { get; set; }

        public string Cpf { get; set; } = string.Empty;

        public double Media { get; set; }

        public bool Ativo { get; set; } = true;

        public bool Aprovado => Media >= 7;

    }
}
