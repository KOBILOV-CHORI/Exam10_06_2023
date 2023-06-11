using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Region
{
    public Region()
    {
        Countries = new List<Country>();
    }

    [Key] public int Id { get; set; }
    [Required, MaxLength(25)] public string? RegionName { get; set; }
    public List<Country> Countries { get; set; }
}