using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class AlunoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = "";

        public DateOnly DataNascimento { get; set; }

        public string Cpf { get; set; } = "";

        public double Media { get; set; }

        public bool Ativo { get; set; } = true;

        public bool Aprovado
        {
            get
            {
                return Media >= 7;
            }
        }
    }
}
