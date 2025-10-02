using WebApi.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Configurando o CORS, responsável por permitir o acesso do front-end ao back-end
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7069") // Porta do seu front-end
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline for development.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilita o CORS
app.UseCors();

app.MapWeatherForecastEndpoints();
app.MapGerenciamentoTurmaEndpoints();

app.Run();
