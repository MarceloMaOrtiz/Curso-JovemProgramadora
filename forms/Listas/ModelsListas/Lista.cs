namespace ModelsListas
{
    public class Lista
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAtualizacao { get; private set; }

        public List<Exercicio> Exercicios { get; set; } = new();

        public Lista(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;

        }

        public void AddExercicio(Exercicio exercicio)
        {
            this.Exercicios.Add(exercicio);
        }
    }
}
