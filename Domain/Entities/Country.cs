using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Country
{
    public Country()
    {
        Locations = new List<Location>();
    }
    [Key] public int Id { get; set; }
    [Required, MaxLength(40)] public string? CountryName { get; set; }
    public int RegionId { get; set; }
    public Region? Region { get; set; }
    public List<Location> Locations { get; set; }
}