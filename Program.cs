using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POO_A4.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//dbcontext
//builder.Services.AddDbContext<DbContext>();
// Configuração do PetDbContext para uso com o banco de dados em memória
builder.Services.AddDbContext<PetDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Quando em desenvolvimento o InMomeoryDatabase vai iniciar com dados para facilitar testes.
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<PetDbContext>();
        DbInitializer.Seed(context);
    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();