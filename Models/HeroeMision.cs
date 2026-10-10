namespace HeroesFluent.Models;

public class HeroeMision
{
    public int HeroeId { get; set; }
    public Heroe Heroe { get; set; } = null!;

    public int MisionId { get; set; }
    public Mision Mision { get; set; } = null!;

    public string Rol { get; set; } = string.Empty;
    public DateTime FechaAsignacion { get; set; }
}