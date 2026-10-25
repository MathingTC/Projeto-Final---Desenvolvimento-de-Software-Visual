namespace Api.DTOs;

public class CadastrarReceitaDTO
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public List<IngredienteReceitaDTO> Ingredientes { get; set; } = [];
    public List<EtapaDTO> Etapas { get; set; } = [];
}