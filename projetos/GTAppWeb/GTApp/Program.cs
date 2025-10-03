var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();  // index.html automático
app.UseStaticFiles();   // libera wwwroot

app.Run();