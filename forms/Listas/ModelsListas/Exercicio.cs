using System;

namespace ModelsListas
{
    public class Exercicio
    {

        public int Id { get; private set };
        public string Nome { get; private set };
        public string Titulo { get; private set };
        public string Descricao { get; private set };
        public string Resposta { get; private set };

        public DateTime DataCriacao { get : private set };
        public DateTime DataAtualizacao { get : private set };

        public Exercicio(string nome, string titulo, string descricao, string resposta)
        {
            this.Nome = nome;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Resposta = resposta;
        }

    }
}