using APICatalogo.Context;
using APICatalogo.Filters;
using APICatalogo.Repository.Implementacao;
using APICatalogo.Repository.Interfaces;
using APICatalogo.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ApiLoggingFilter>();
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string SqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(SqlConnection, ServerVersion.AutoDetect(SqlConnection)));
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(SqlConnection)); //utilizado para sqlserver

builder.Services.AddTransient<IMeuServico,MeuServico>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
