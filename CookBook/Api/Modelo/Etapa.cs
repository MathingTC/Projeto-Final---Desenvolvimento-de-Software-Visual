namespace Api.modelo;

public class Etapa
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public int Ordem {get;set;}
    public string Descricao {get;set;} = string.Empty;
    public string ReceitaId {get;set;} = string.Empty;
    public Receita? Receita {get;set;}
}