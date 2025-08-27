using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunosModels.ValueObject
{
    public class Cpf
    {
        public string Valor { get; set; } = string.Empty;
        public Cpf(string valor)
        {

            valor = valor?.Trim() ?? string.Empty;
            valor = new string(valor.Where(char.IsDigit).ToArray());

            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("CPF não pode ser vazio.");
            else if (valor.Length != 11 || !valor.All(char.IsDigit))
                throw new ArgumentException("CPF deve conter 11 dígitos numéricos.");
            else if (!ValidarCpf(valor))
                throw new ArgumentException("CPF inválido.");
            else
            {
                Valor = valor;
            }

        }

        // Retornar true se o CPF for válido, false caso contrário
        private bool ValidarCpf(string cpf)
        {
            int[] primeirosMulti = new int[9];
            int[] segundosMulti = new int[10];

            int somaMultiUm = 0, somaMultiDois;
            int verificadorUm, verificadorDois;

            for (int i = 0; i < 9; i++)
                primeirosMulti[i] = Convert.ToInt32(cpf[i].ToString()) * (i + 1);

            somaMultiUm = primeirosMulti.Sum();

            verificadorUm = somaMultiUm % 11;
            if (verificadorUm == 10) verificadorUm = 0;

            if (verificadorUm != Convert.ToInt32(cpf[9].ToString()))
                return false;

            for (int i = 0; i < 10; i++)
            {
                segundosMulti[i] = Convert.ToInt32(cpf[i].ToString()) * i;
            }

            somaMultiDois = segundosMulti.Sum();

            verificadorDois = somaMultiDois % 11;
            if (verificadorDois == 10) verificadorDois = 0;

            if (verificadorDois != Convert.ToInt32(cpf[10].ToString()))
                return false;

            return true;
        }

        public override string ToString()
        {
            return $"{Valor.Substring(0, 3)}.{Valor.Substring(3, 3)}.{Valor.Substring(6, 3)}-{Valor.Substring(9, 2)}";
        }
    }
}
