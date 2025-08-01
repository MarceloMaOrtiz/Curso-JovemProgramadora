namespace ModelsListas
{
    public class Lista
    {
        private static int proximoId = 1;

        private int _id;
        private string _nome;
        private string _descricao;
        private int _qtdQuestoes;

        Lista<Exercicio> exercicios = new List<Exercicio>();

        public Lista(string nome, string descricao)
        {
            this._nome = nome;
            this._descricao = descricao;
            this._qtdQuestoes = 0;
        }

        public void AddExercicio(Exercicio exercicio)
        {
            this.exercicios.Add(exercicio);
        }
    }
}
