using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class CadastroAlunoDto
    {
        public required string Nome { get; set; }
        public required DateOnly DataNascimento { get; set; }
        public required string Cpf { get; set; }
        public required double Media { get; set; }
    }
}
