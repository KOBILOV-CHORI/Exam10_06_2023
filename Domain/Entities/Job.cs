using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Job
{
    public Job()
    {
        Employees = new List<Employee>();
        JobHistories = new List<JobHistory>();
    }
    [Key] public int Id { get; set; }
    [Required, MaxLength(35)] public string? JobTitle { get; set; }
    [Required] public int MinSalary { get; set; }
    [Required] public int MaxSalary { get; set; }
    public List<Employee> Employees { get; set; }
    public List<JobHistory> JobHistories { get; set; }
}