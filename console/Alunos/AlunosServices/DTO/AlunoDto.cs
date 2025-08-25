using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunosServices.DTO
{
    public class AlunoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public DateOnly DataNascimento { get; set; }

        public string Cpf { get; set; } = string.Empty;

        public double Media { get; set; }

        public bool Ativo { get; set; } = true;

        public bool Aprovado => Media >= 7;

        public override string ToString()
        {
            return $"Nome: {Nome} | Data de Nascimento: {DataNascimento.ToString("dd/MM/yyyy")} | CPF: {Cpf} | Média: {Media}";
        }
    }
}
