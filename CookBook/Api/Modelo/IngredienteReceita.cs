namespace Api.modelo;
public class IngredienteReceita
{
    public Guid ReceitaId {get;set;}
    public Receita? Receita {get;set;}
    public Guid IngredienteId {get;set;}
    public Ingrediente? Ingrediente {get;set;}
    public float? Quantidade {get;set;}
    public string UnidadeMedida {get;set;} = string.Empty;
}
