using ChargeTechApi.Data;
using ChargeTechApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração dos repositórios
builder.Services.AddScoped<IAmbienteRepository, AmbienteRepository>();
builder.Services.AddScoped<IConsumoEnergeticoRepository, ConsumoEnergeticoRepository>();
builder.Services.AddScoped<IDispositivoRepository, DispositivoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Configuração de controllers
builder.Services.AddControllers();

// Configuração do Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
