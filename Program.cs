
var builder = WebApplication.CreateBuilder(args);

// Adiciona os controladores ao container de serviços
builder.Services.AddControllers();

// Adiciona o Swagger (para documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o roteamento dos controladores
app.UseRouting();

app.UseEndpoints(endpoints => {
    _=endpoints.MapControllers();
});

// Configurações para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
