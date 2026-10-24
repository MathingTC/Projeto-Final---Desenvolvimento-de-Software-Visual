public class Receita
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public string Nome {get;set;} = string.Empty;
    public string Descricao {get;set;} = string.Empty;
    public List<IngredienteReceita> IngredienteReceitas {get;set;} = [];
    public List<Ingrediente> Ingredientes {get;set;} = [];
    public List<Etapa> Etapas {get;set;} = [];
}
