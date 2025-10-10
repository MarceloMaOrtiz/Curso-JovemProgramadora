using Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class DesativarAlunoDto
    {
        public required string Cpf { get; set; }
    }
}
