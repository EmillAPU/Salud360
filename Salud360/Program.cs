using Microsoft.EntityFrameworkCore;
using Salud360.Data;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Salud360.Services.AulaServices;
using Salud360.Services.FavoritoServices;
using Salud360.Services.PlanNutricionalServices;
using Salud360.Models;
using Salud360.Services.ProductoAlimenticioServices;
using Salud360.Services.ProgresoUsuarioServices;
using Salud360.Services.UsuarioServices;
using Salud360.Services.VerificacionUsuarioServices;

var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar AutoMapper con typeof(Program) en lugar de MappingProfile
builder.Services.AddAutoMapper(typeof(Program));

// Registrar Servicios
builder.Services.AddScoped<IEjercicioService, EjercicioService>();
builder.Services.AddScoped<IFavoritoService, FavoritoService>();
builder.Services.AddScoped<IPlanNutricionalService, PlanNutricionalService>();
builder.Services.AddScoped<IProductoAlimenticioService, ProductoAlimenticioService>();
builder.Services.AddScoped<IProgresoUsuarioService, ProgresoUsuarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVerificacionUsuarioService, VerificacionUsuarioService>();

// Configurar Controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
