using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Department
{
    public Department()
    {
        JobHistories = new List<JobHistory>();
        Employees = new List<Employee>();
    }
    [Key]public int Id { get; set; }
    [Required, MaxLength(30)] public string? DepartmentName { get; set; }
    public int LocationId { get; set; }
    public Location? Location { get; set; }
    public List<JobHistory> JobHistories { get; set; }
    public List<Employee> Employees { get; set; }
}