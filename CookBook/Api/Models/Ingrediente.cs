public class Ingrediente
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public string Nome {get;set;} = string.Empty;
    public List<IngredienteReceita> IngredienteReceitas { get; set; } = [];
    public List<Receita> Receitas { get; set; } = [];
}
