using Models.ValueObjects;
using Services;
using Services.Dto;

namespace GTApi.Routers
{
    public static class GTEndPoints
    {
        public static void MapGTEndPoints(this IEndpointRouteBuilder app)
        {
            //app.MapGet("/getapi/buscar_aluno", (string cpf) =>
            app.MapGet("/gtapi/buscar_aluno", (string cpf) =>
            {
                Cpf cpfObj;
                try
                {
                    cpfObj = new Cpf(cpf);
                    RespostaServico<AlunoDto?> resposta = ServicesAluno.BuscarAlunoCpf(cpfObj);
                    if (!resposta.Sucesso)
                    {
                        return Results.Problem(resposta.Mensagem);
                    }
                    return Results.Ok(resposta);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    RespostaServico<object> resposta = new RespostaServico<object>(null, false, ex.Message);
                    return Results.BadRequest(resposta);
                }
            })
            .WithName("GetAlunoCpf").
            WithOpenApi();

            app.MapPut("/gtapi/remover_aluno", (DesativarAlunoDto dto) =>
            {
                Cpf cpfObj;
                try
                {
                    cpfObj = new Cpf(dto.Cpf);
                    RespostaServico<AlunoDto?> resp = ServicesAluno.BuscarAlunoCpf(cpfObj);
                    if (!resp.Sucesso)
                    {
                        return Results.Problem(resp.Mensagem);
                    }
                    else
                    {
                        if (resp.Objeto != null)
                        {
                            RespostaServico<AlunoDto> respDesativar = ServicesAluno.DesativarAluno(resp.Objeto);
                            return Results.Ok(resp);
                        }
                        else
                            return Results.NotFound(resp.Mensagem);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    RespostaServico<object> resposta = new RespostaServico<object>(null, false, ex.Message);
                    return Results.BadRequest(resposta);
                }
            })
            .WithName("PutRemoverAluno")
            .WithOpenApi();

            app.MapGet("/gtapi/alunos", () =>
            {
                RespostaServico<List<AlunoDto>> resposta = ServicesAluno.ListarAlunos();
                if (!resposta.Sucesso)
                {
                    return Results.Problem(resposta.Mensagem);
                }
                return Results.Ok(resposta);
            })
            .WithName("GetAlunos")
            .WithOpenApi();

            app.MapGet("/gtapi/aprovados", () =>
            {
                RespostaServico<List<AlunoDto>> resposta = ServicesAluno.ListarAprovados();
                if (!resposta.Sucesso)
                {
                    return Results.Problem(resposta.Mensagem);
                }
                return Results.Ok(resposta);
            })
            .WithName("GetAprovados")
            .WithOpenApi();

            app.MapGet("/gtapi/reprovados", () =>
            {
                RespostaServico<List<AlunoDto>> resposta = ServicesAluno.ListarReprovados();
                if (!resposta.Sucesso)
                {
                    return Results.Problem(resposta.Mensagem);
                }
                return Results.Ok(resposta);
            })
            .WithName("GetReprovados")
            .WithOpenApi();

            app.MapPost("/gtapi/cadastro_aluno", (AlunoDto aluno) =>
            {
                var resposta = ServicesAluno.CadastrarAluno(aluno);
                if (!resposta.Sucesso)
                {
                    return Results.Problem(resposta.Mensagem);
                }
                return Results.Ok(resposta);
            })
            .WithName("CadastroAluno")
            .WithOpenApi();
        }
    }
}
