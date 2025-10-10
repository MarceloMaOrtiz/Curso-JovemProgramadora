using Services;
using Services.Dto;

namespace GTApi.Routers
{
    public static class GTEndPoints
    {
        public static void MapGTEndPoints(this IEndpointRouteBuilder app)
        {
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
