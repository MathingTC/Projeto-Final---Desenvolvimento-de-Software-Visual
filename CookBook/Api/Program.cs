using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

//Endpoint para cadastrar um ingrediente POST
app.MapPost("/api/ingredientes/cadastrar", (
    [FromBody] Ingrediente? ing, 
    [FromServices] AppDataContext ctx) =>
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

//Endpoint para listar ingredientes em ordem alfabetica
app.MapGet("/api/ingredientes/listar", (
    [FromServices] AppDataContext ctx) =>
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
