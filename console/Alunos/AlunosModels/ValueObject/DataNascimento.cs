using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunosModels.ValueObject
{
    public class DataNascimento
    {
        public DateOnly Valor { get; set; }

        public DataNascimento(DateOnly valor)
        {
            if (valor > DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException("Data de nascimento não pode ser no futuro.");
            else if(valor > DateOnly.FromDateTime(DateTime.Now).AddYears(-18))
                throw new ArgumentException("Proibido menores de idade.");
            else
                Valor = valor;
        }
    }
}
