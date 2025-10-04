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
        }
    }
}
