using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.ModelViews;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.Dominio.Entidades;

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdmnistradorServico, AdmnistradorServico>();
builder.Services.AddScoped<IVeiculoServico, VeiculoServico>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});
#endregion


var app = builder.Build();

#region Home
app.MapGet("/", () => Results.Json(new Home()));
#endregion

#region Admnistrador
app.MapPost("/admnistradores/login", ([FromBody] LoginDTO loginDTO, IAdmnistradorServico admnistradorServico) => {
    if(admnistradorServico.Login(loginDTO) != null) {
        return Results.Ok("Login com sucesso");
    } else {
        return Results.Unauthorized();
    }
});
#endregion

#region Veiculos
app.MapPost("/veiculos", ([FromBody] VeiculoDTO veiculoDTO, IVeiculoServico veiculoServico) => {
    Veiculo veiculo = new Veiculo {
        Nome = veiculoDTO.Nome,
        Marca = veiculoDTO.Marca,
        Ano = veiculoDTO.Ano
    };
    
    veiculoServico.Incluir(veiculo);
    return Results.Created($"/veiculos/{veiculo.Id}", veiculo);
});
#endregion

#region App
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
#endregion