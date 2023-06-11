using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class JobHistory
{
    public Employee? Employee { get; set; }
    [Key] public int EmployeeId { get; set; }
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }
    public Job? Job { get; set; }
    public int JobId { get; set; }
    public Department? Department { get; set; }
    public int DepartmentId { get; set; }
}