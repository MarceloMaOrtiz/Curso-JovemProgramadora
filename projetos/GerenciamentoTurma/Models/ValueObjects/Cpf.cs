using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ValueObjects
{
    public class Cpf
    {
        public string Valor { get; private set; } = String.Empty;

        public Cpf(string valor)
        {
            Console.WriteLine("ANTES: " + valor);

            valor = valor.Replace(".", "").Replace("-", "").Trim();
            valor = new string(valor.Where(char.IsDigit).ToArray());

            Console.WriteLine("DEPOIS: " + valor);

            if(valor == "00000000000")
            {
                throw new ArgumentException("CPF 000.000.000-00 é inválido.");
            }
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

        private bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma * 10 % 11;
            if (resto == 10)
                resto = 0;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma * 10 % 11;
            if (resto == 10)
                resto = 0;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
