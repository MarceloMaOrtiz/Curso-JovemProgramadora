using Services;
using Services.Dto;

namespace WebApi.EndPoints
{
    public static class GerenciamentoTurmaEndPoints
    {
        public static void MapGerenciamentoTurmaEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/alunos", () =>
            {
                RespostaServico<List<AlunoDto>> resposta = ServicesAluno.ListarAlunos();
                if(!resposta.Sucesso)
                {
                    return Results.Problem(resposta.Mensagem);
                }
                return Results.Ok(resposta);

            })
            .WithName("GetAlunos")
            .WithOpenApi();
        }
    }
}
