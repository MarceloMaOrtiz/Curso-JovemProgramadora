using Models;
using MySqlConnector;

namespace Repository
{
    public static class RepositoryAluno
    {
        public static bool TestarConexao()
        {
            try
            {
                using (var connection = new MySqlConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool ExisteCpf(string cpf)
        {
            // TODO: Implementar a lógica para verificar se o CPF já existe na base de dados.
            return false;
        }

        public static Aluno CadastrarAluno(Aluno aluno)
        {
            // TODO: Implementar a lógica para cadastrar o aluno na base de dados.
            return aluno;
        }

        public static (List<Aluno>, bool, string) ListarAlunos()
        {
            List<Aluno> alunos = new List<Aluno>();
            try
            {
                using (var connection = new MySqlConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM alunos WHERE ativo = true;";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Aluno aluno = new Aluno
                            {
                                Id = reader.GetInt32("id_aluno"),
                                Nome = reader.GetString("nome"),
                                DataNascimento = reader.GetDateOnly("dt_nascimento"),
                                Cpf = reader.GetString("cpf"),
                                Media = reader.GetDouble("media"),
                                Ativo = reader.GetBoolean("ativo")
                            };
                            alunos.Add(aluno);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (alunos, false, ex.Message);
            }
            return (alunos, true, "Select realizado");
        }
    }
}
