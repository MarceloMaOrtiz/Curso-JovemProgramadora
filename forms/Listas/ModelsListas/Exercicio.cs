using System;

namespace ModelsListas
{
	public class Exercicio
	{
		private static int proximoId = 1;

		public int Id { get; private set };
		public string Nome { get; private set };
		public string Titulo { get; private set };
		public string Descricao { get; private set };
		public string Resposta { get; private set };

		public Exercicio(string nome, string titulo, string descricao, string resposta)
		{
			this.Id = proximoId;
			this.Nome = nome;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Resposta = resposta;
			proximoId++;
		}

	}
}