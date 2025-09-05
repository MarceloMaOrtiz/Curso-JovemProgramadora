using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ValueObjects
{
    public class Cpf
    {
        public string Valor { get; set; } = String.Empty;

        public Cpf(string valor)
        {
            valor = valor.Replace(".", "").Replace("-", "").Trim();

            if(valor.Length != 11)
            {
                throw new ArgumentException("CPF deve conter 11 dígitos.");
            }
            if (!ValidarCpf(valor))
            {
                throw new ArgumentException("CPF inválido.");
            }
            Valor = valor;
        }
    }
}
