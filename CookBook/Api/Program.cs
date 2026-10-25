using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Api.DTOs;

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

// -- Endpoint Cadastrar Receitas
app.MapPost("/api/receitas/cadastrar", (
    [FromBody] CadastrarReceitaDTO? receita,
    [FromServices] AppDataContext ctx) =>
{
    if (receita == null)
    {
        return Results.BadRequest("Dados inválidos.");
    }
    if (string.IsNullOrWhiteSpace(receita.Nome))
    {
        return Results.BadRequest("O nome da receita não pode ser vazio.");
    }

    // -- verifica se o ingrediente existe no banco de dados
    foreach (var ingrediente in receita.Ingredientes)
    {
        bool existe = ctx.Ingredientes.Any(i => i.Id == ingrediente.IngredienteId);

        if (!existe)
        {
            return Results.BadRequest("Um dos ingredientes não está cadastrado no banco de dados");
        }

        // -- quantidade deve ser maior que zero
        if (ingrediente.Quantidade == null || ingrediente.Quantidade <= 0)
        {
            return Results.BadRequest("A quantidade deve ser maior que zero.");
        }

        // -- unidade de medida não pode ser vazia.
        if (string.IsNullOrWhiteSpace(ingrediente.UnidadeMedida))
        {
            return Results.BadRequest("A unidade de medida não pode ser vazia.");
        }
    }
    // -- verifica se tem ingredientes repetidos
    if (receita.Ingredientes.Select(i => i.IngredienteId).Distinct().Count()
        != receita.Ingredientes.Count)
    {
        return Results.BadRequest("Não pode repetir o mesmo ingrediente na receita.");
    }
     // -- verifica se as etapas estão na ordem: 1,2,3...
    var etapasOrdenadas = receita.Etapas.OrderBy(e => e.Ordem).ToList();

    int ordemEsperada = 1;

    foreach (var etapa in etapasOrdenadas)
    {
        if (etapa.Ordem != ordemEsperada)
        {
            return Results.BadRequest("As etapas devem ter ordem sequencial, começando em 1.");
        }
        ordemEsperada++;
    }

    // -- cria uma nova receita com os dados recebidos do DTO
    Receita novaReceita = new Receita
    {
        Nome = receita.Nome,
        Descricao = receita.Descricao
    };
    
    // -- adiciona os ingredientes na "novaReceita"
    foreach (var ingrediente in receita.Ingredientes)
    {
        novaReceita.IngredienteReceitas.Add(new IngredienteReceita
        {
            IngredienteId = ingrediente.IngredienteId,
            Quantidade = ingrediente.Quantidade,
            UnidadeMedida = ingrediente.UnidadeMedida
        });
    }
    
    // -- adiciona as etapas na nova receita
    foreach (var etapa in receita.Etapas)
    {
        novaReceita.Etapas.Add(new Etapa
        {
            Ordem = etapa.Ordem,
            Descricao = etapa.Descricao
        });
    }
    ctx.Receitas.Add(novaReceita);
    ctx.SaveChanges();

    return Results.Created($"/api/receitas/{novaReceita.Id}", novaReceita.Id);
});

app.Run();
