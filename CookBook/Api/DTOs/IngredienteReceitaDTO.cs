namespace Api.DTOs;

public class IngredienteReceitaDTO
{
    public Guid IngredienteId { get; set; }
    public float? Quantidade { get; set; }
    public string UnidadeMedida { get; set; } = string.Empty;
}