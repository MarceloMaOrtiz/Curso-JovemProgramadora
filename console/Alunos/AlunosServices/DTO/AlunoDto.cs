using AlunosModels.ValueObject;
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

        public required DataNascimento DtNascimento { get; set; }

        public required Cpf Cpf { get; set; }

        public double Media { get; set; }

        public bool Ativo { get; set; } = true;

        public bool Aprovado => Media >= 7;

        public override string ToString()
        {
            return $"Nome: {Nome} | Data de Nascimento: {DtNascimento.Valor.ToString("dd/MM/yyyy")} | CPF: {Cpf} | Média: {Media}";
        }
    }
}
