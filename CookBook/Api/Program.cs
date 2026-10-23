using Api.Data; // Renomear 'AppDbContext' para 'AppDataContext'
using Microsoft.AspNetCore.Mvc;
using Api.modelo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

//Endpoint para cadastrar um ingrediente POST
app.MapPost("/api/ingredientes/cadastrar", (
    [FromBody] Ingrediente? ing, 
    [FromServices] AppDbContext ctx) =>
{
    if (ing == null)
    {
        return Results.BadRequest("O ingrediente não pode ser nulo.");
    }
     if(ing.Nome == "")
    {
        return Results.BadRequest("O nome do ingrediente não pode ser vazio.");
    }

    Ingrediente? ingEncontrado = ctx.Ingredientes.FirstOrDefault(x => x.Nome == ing.Nome);
    if (ingEncontrado is not null)
    {
        return Results.BadRequest("Esse ingrediente já existe!.");

    }

    ctx.Ingredientes.Add(ing);
    ctx.SaveChanges();
    return Results.Created("",ing);

});

app.Run();
