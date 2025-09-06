using Models.ValueObjects;
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

        public required DataNascimento DataNascimento { get; set; }

        public Cpf Cpf { get; set; } = new Cpf("");

        public double Media { get; set; }

        public bool Ativo { get; set; } = true;

        public bool Aprovado
        {
            get
            {
                return Media >= 7;
            }
        }

        public override string ToString()
        {
            return $"Nome: {Nome} - Data de nascimento: {DataNascimento} - CPF: {Cpf} - Média: {Media}";
        }
    }
}
