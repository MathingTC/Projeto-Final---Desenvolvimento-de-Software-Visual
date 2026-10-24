public class IngredienteReceita
{
    public Guid ReceitaId {get;set;}
    public Receita Receita {get;set;} = null!;
    public Guid IngredienteId {get;set;}
    public Ingrediente Ingrediente {get;set;} = null!;
    public float? Quantidade {get;set;}
    public string UnidadeMedida {get;set;} = string.Empty;
}
