using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//(AlunoDto ?, bool, string)

namespace Services
{
    public class RespostaServico<T>
    {
        public T? Objeto { get; set; }

        public bool Sucesso { get; set; }

        public string Mensagem { get; set; } = string.Empty;

        public RespostaServico(T? objeto, bool sucesso, string mensagem)
        {
            Objeto = objeto;
            Sucesso = sucesso;
            Mensagem = mensagem;
        }
    }
}
