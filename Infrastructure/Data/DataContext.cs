using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobHistory> JobsHistories { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<JobGrade> JobsGrades { get; set; }
}