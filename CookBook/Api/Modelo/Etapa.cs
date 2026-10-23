namespace Api.modelo;

public class Etapa
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public int Ordem {get;set;}
    public string Descricao {get;set;} = string.Empty;
    public Guid ReceitaId {get;set;}
    public Receita? Receita {get;set;}
}
