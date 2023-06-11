using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class JobGrade
{
    [Key] public string? GradeLevel { get; set; }
    [Required] public decimal LowestSal { get; set; }
    [Required] public decimal HighestSal { get; set; }
}