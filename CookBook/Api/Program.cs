using Microsoft.EntityFrameworkCore;
using Api.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("ingredientes", (
    [FromServices] AppDbContext ctx) =>
{
    var ingredientes = ctx.Ingredientes
        .OrderBy(i => i.Nome)
        .Select(i => new
        {
            i.Id,
            i.Nome
        })
        .ToList();
    
    if (ingredientes.Count == 0)
    {
        return Results.Ok("Lista de ingredientes vazia!");
    }

    return Results.Ok(ingredientes);
});

app.Run();
