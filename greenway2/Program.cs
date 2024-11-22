using greenway2.DTOs;
using greenway2.Repositories;
using greenway2.Services;
using greenway2.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��es do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDbContext"));
});

// Registrar os reposit�rios e servi�os espec�ficos
builder.Services.AddScoped<IGenericRepository<LoginDTO>, LoginRepository>(); // Registra o reposit�rio espec�fico
builder.Services.AddScoped<LoginService>();

builder.Services.AddScoped<VeiculoRepository>();
builder.Services.AddScoped<VeiculoService>();

builder.Services.AddScoped<IGenericRepository<CadastroDTO>, CadastroRepository>();
builder.Services.AddScoped<CadastroService>();

builder.Services.AddScoped<IGenericRepository<HistoricoDTO>, HistoricoRepository>();
builder.Services.AddScoped<HistoricoService>();

// Adiciona Controllers com Views
builder.Services.AddControllersWithViews();

// Configura��o de CORS (caso precise)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();

// Habilitar arquivos est�ticos (caso use)
app.UseStaticFiles();

// Habilitar roteamento
app.UseRouting();

// Definir a rota padr�o para o HomeController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Rota espec�fica para o VeiculoController
app.MapControllerRoute(
    name: "veiculoRoute",
    pattern: "{controller=Veiculo}/{action=Index}/{id?}");

// Rota espec�fica para o LoginController
app.MapControllerRoute(
    name: "loginRoute",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "cadastroRoute",
    pattern: "{controller=Cadastro}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "historicoRoute",
    pattern: "{controller=Historico}/{action=Index}/{id?}");



app.Run();
