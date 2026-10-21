namespace Api.modelo;

public class Ingrediente
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public string Nome {get;set;} = string.Empty;
    public List<IngredienteReceita> IngredienteReceita { get; set; } = new();
    public List<Receita> Receitas {get;set;} = new();
}