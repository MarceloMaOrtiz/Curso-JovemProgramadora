using Models.ValueObjects;
using Services;
using Services.Dto;
using Services.Dto.Serializers;

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

            //gtapi/buscar_aluno?cpf=12225832757
            app.MapGet("/gtapi/buscar_aluno", (string cpf) =>
            {
                try
                {
                    Cpf cpfObject = new Cpf(cpf);
                    RespostaServico<AlunoDto?> resposta = ServicesAluno.BuscarAlunoCpf(cpfObject);
                    if (!resposta.Sucesso)
                    {
                        return Results.Problem(resposta.Mensagem);
                    }
                    if(resposta.Objeto == null)
                    {
                        return Results.NotFound(resposta);
                    }
                    return Results.Ok(resposta);
                }catch(Exception ex)
                {
                    RespostaServico<object> resp = new RespostaServico<object>(null, false, ex.Message);
                    return Results.BadRequest(resp);
                }
            })
            .WithName("GetBuscarAluno")
            .WithOpenApi();

            app.MapPost("/gtapi/cadastro_aluno", (CadastroAlunoDto aluno) =>
            {
                try
                {
                    AlunoDto alunoDto = AlunoSerializer.CadastroToAlunoDto(aluno);
                    var resposta = ServicesAluno.CadastrarAluno(alunoDto);
                    if (!resposta.Sucesso)
                    {
                        return Results.Problem(resposta.Mensagem);
                    }
                    return Results.Ok(resposta);
                }
                catch (Exception ex)
                {
                    RespostaServico<object> resposta = new RespostaServico<object>(null, false, ex.Message);
                    return Results.BadRequest(resposta);
                }
            })
            .WithName("CadastroAluno")
            .WithOpenApi();
        }
    }
}
