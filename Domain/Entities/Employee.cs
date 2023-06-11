using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee
{
    public Employee()
    {
        JobHistories = new List<JobHistory>();
    }
    [Key] public int Id { get; set; }
    [Required, MaxLength(20)] public string? FirstName { get; set; }
    [Required, MaxLength(25)] public string? LastName { get; set; }
    [Required, MaxLength(50)] public string? Email { get; set; }
    [Required, MaxLength(20)] public string? Phone { get; set; }
    [Required] public DateTime HireDate { get; set; }
    public Job? Job { get; set; }
    public int JobId { get; set; }
    [Required] public int Salary { get; set; }
    [Required] public decimal CommissionPct { get; set; }
    [Required] public int ManagerId { get; set; }
    public Department? Department { get; set; }
    public int DepartmentId { get; set; }
    public List<JobHistory> JobHistories { get; set; }
}