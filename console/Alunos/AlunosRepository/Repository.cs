using AlunosModels;
using AlunosModels.ValueObject;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace AlunosRepository
{
    public static class Repository
    {
        private static string? sqlConnectionString {
            get
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
                return config.GetConnectionString("DefaultConnection");
            }
        }

        public static (bool, bool, string) TestarConexao()
        {
            try
            {
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    return (true, true, "Conexão bem-sucedida!");
                }
            }
            catch (Exception ex)
            {
                return (false, false, $"Erro ao conectar: {ex.Message}");
            }
        }

        public static (bool, bool, string) ExisteCpf(Cpf cpf)
        {
            bool encontrado = false;
            try
            {
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT COUNT(*) FROM aluno WHERE cpf = @Cpf;";
                    command.Parameters.AddWithValue("@Cpf", cpf.Valor);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    encontrado = count > 0;
                }
                if (encontrado)
                {
                    return (true, true, "CPF encontrado.");
                }
                else
                {
                    return (false, true, "CPF não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return (false, false, $"Erro ao verificar CPF: {ex.Message}");
            }
        }

        public static (Aluno, bool, string) CadastrarAluno(Aluno aluno)
        {
            try
            {
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO aluno (nome, dt_nascimento, cpf, media) VALUES (@Nome, @DataNascimento, @Cpf, @Media);";
                    command.Parameters.AddWithValue("@Nome", aluno.Nome);
                    command.Parameters.AddWithValue("@DataNascimento", aluno.DtNascimento.Valor.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Cpf", aluno.Cpf.Valor);
                    command.Parameters.AddWithValue("@Media", aluno.Media);
                    command.ExecuteNonQuery();
                    aluno.Id = (int)command.LastInsertedId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar aluno: {ex.Message}");
                return (aluno, false, ex.Message);
            }
            return (aluno, true, $"{aluno.Nome} cadastrado com sucesso.");
        }

        public static (Aluno, bool, string) AtualizarAluno(Aluno aluno)
        {
            try
            {
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE aluno SET nome = @Nome, dt_nascimento = @DataNascimento, cpf = @Cpf, media = @Media, ativo = @Ativo WHERE id_aluno = @Id;";
                    command.Parameters.AddWithValue("@Id", aluno.Id);
                    command.Parameters.AddWithValue("@Nome", aluno.Nome);
                    command.Parameters.AddWithValue("@DataNascimento", aluno.DtNascimento.Valor.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Cpf", aluno.Cpf.Valor);
                    command.Parameters.AddWithValue("@Media", aluno.Media);
                    command.Parameters.AddWithValue("@Ativo", aluno.Ativo);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return (aluno, false, ex.Message);
            }
            return (aluno, true, $"{aluno.Nome} atualizado com sucesso.");
        }

        public static (Aluno?, bool, string) BuscarAlunoCpf(Cpf cpf)
        {
            try
            {
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM aluno WHERE cpf = @Cpf;";
                    command.Parameters.AddWithValue("@Cpf", cpf.Valor);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                new Aluno
                                {
                                    Id = reader.GetInt32("id_aluno"),
                                    Nome = reader.GetString("nome"),
                                    DtNascimento = new DataNascimento(reader.GetDateOnly("dt_nascimento")),
                                    Cpf = new Cpf(reader.GetString("cpf")),
                                    Media = reader.GetDouble("media"),
                                    Ativo = reader.GetBoolean("ativo")
                                },
                                true,
                                "Busca executada."
                            );
                        }
                        else
                        {
                            return (null, false, "Aluno não encontrado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (
                    null,
                    false,
                    $"Erro ao buscar aluno: {ex.Message}"
                );
            }
        }

        public static (List<Aluno>, bool, string) ListarAtivos()
        {
            List<Aluno> alunos = new List<Aluno>();
            try
            {
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM aluno WHERE ativo = true;";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Aluno aluno = new Aluno
                            {
                                Id = reader.GetInt32("id_aluno"),
                                Nome = reader.GetString("nome"),
                                DtNascimento = new DataNascimento(reader.GetDateOnly("dt_nascimento")),
                                Cpf = new Cpf(reader.GetString("cpf")),
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
            return (alunos, true, "Lista de alunos ativos recuperada com sucesso.");
        }
    }
}
