using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ValueObjects
{
    public class DataNascimento
    {
        public DateOnly Valor { get; private set; }

        public DataNascimento(DateOnly valor)
        {
            
            if (valor > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Data de nascimento não pode ser no futuro.");
            }
            if (DateTime.Now.Year - valor.Year > 150)
            {
                throw new ArgumentException("Data de nascimento inválida. Velho demais.");
            }
            Valor = valor;
        }
    }
}
