using Models;
using MySqlConnector;

namespace Repository
{
    public static class RepositoryAluno
    {
        private static readonly string _connectionString = "Server=localhost;User Id=root;Database=turma;password=root";

        public static bool TestarConexao()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
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

        public static (bool, bool, string) ExisteCpf(string cpf)
        {
            // TODO: Implementar a lógica para verificar se o CPF já existe na base de dados.
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    // Sql Injection
                    //command.CommandText = $"SELECT COUNT(*) FROM alunos WHERE cpf = {cpf};";
                    command.CommandText = "SELECT COUNT(*) FROM alunos WHERE cpf = @cpf;";
                    command.Parameters.AddWithValue("@cpf", cpf);
                    var count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                        return (true, true, "CPF encontrado.");
                    else
                        return (false, true, "CPF não foi encontrado");
                }
            }catch (Exception ex)
            {
                return (false, false, ex.Message);
            }
        }

        public static (Aluno?, bool, string) BuscarAlunoCpf(string cpf)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM alunos WHERE cpf = @cpf;";
                    command.Parameters.AddWithValue("@cpf", cpf);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
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
                            return (aluno, true, "Aluno encontrado");
                        }
                        else
                        {
                            return (null, true, "Aluno não encontrado");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (null, false, ex.Message);
            }
        }

        public static (Aluno, bool, string) AtualizarAluno(Aluno aluno)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE alunos SET nome = @nome, dt_nascimento = @dt_nascimento, cpf = @cpf, media = @media, ativo = @ativo WHERE id_aluno = @id_aluno;";
                    command.Parameters.AddWithValue("@id_aluno", aluno.Id);
                    command.Parameters.AddWithValue("@nome", aluno.Nome);
                    command.Parameters.AddWithValue("@dt_nascimento", aluno.DataNascimento);
                    command.Parameters.AddWithValue("@cpf", aluno.Cpf);
                    command.Parameters.AddWithValue("@media", aluno.Media);
                    command.Parameters.AddWithValue("@ativo", aluno.Ativo);
                    command.ExecuteNonQuery();
                }
            }catch (Exception ex)
            {
                return (aluno, false, ex.Message);
            }
            return (aluno, true, "Aluno atualizado");
        }

        public static (Aluno, bool, string) CadastrarAluno(Aluno aluno)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO alunos (nome, dt_nascimento, cpf, media, ativo) VALUES (@nome, @dt_nascimento, @cpf, @media, @ativo);";
                    command.Parameters.AddWithValue("@nome", aluno.Nome);
                    command.Parameters.AddWithValue("@dt_nascimento", aluno.DataNascimento);
                    command.Parameters.AddWithValue("@cpf", aluno.Cpf);
                    command.Parameters.AddWithValue("@media", aluno.Media);
                    command.Parameters.AddWithValue("@ativo", aluno.Ativo);
                    command.ExecuteNonQuery();
                    aluno.Id = (int)command.LastInsertedId;
                }
            }
            catch (Exception ex)
            {
                return (aluno, false, ex.Message);
            }
            return (aluno, true, "Aluno cadastro");
        }

        public static (List<Aluno>, bool, string) ListarAlunos()
        {
            List<Aluno> alunos = new List<Aluno>();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
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
