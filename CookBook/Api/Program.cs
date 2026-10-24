using Microsoft.EntityFrameworkCore;
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
        return Results.BadRequest("Dados inválidos");
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
    return Results.Created("Ingrediente criado",ing);

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

//Endpoint para deletar ingrediente
app.MapDelete("/api/ingredientes/remover/{id}", (
    [FromRoute] Guid id,
    [FromServices] AppDataContext ctx) =>
{
    var ing = ctx.Ingredientes
        .Include(i => i.Receitas)
        .SingleOrDefault(i => i.Id == id);

    if (ing == null) {
        return Results.NotFound("Ingrediente não encontrado");
    }

    if (ing.Receitas.Any()) {
        return Results.BadRequest("Ingrediente faz parte de receitas e não pode ser deletado");
    }

    ctx.Ingredientes.Remove(ing);
    //ctx.SaveChanges();

    return Results.NoContent();
});

//Endpoint para editar ingrediente
app.MapPut("/api/ingredientes/editar/{id}", (
    [FromRoute] Guid id,
    [FromBody] Ingrediente newIng,
    [FromServices] AppDataContext ctx) =>
{
    if (newIng == null)
    {
        return Results.BadRequest("Dados inválidos");
    }

    if (newIng.Nome == "")
    {
        return Results.BadRequest("O novo nome não pode ser vazio");
    }

    var ing = ctx.Ingredientes.Find(id);
    if (ing == null) {
        return Results.NotFound("Ingrediente não encontrado");
    }

    ing.Nome = newIng.Nome;

    ctx.SaveChanges();

    return Results.Created("Ingrediente atualizado", ing);
});

app.Run();
