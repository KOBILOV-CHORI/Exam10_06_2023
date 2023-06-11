using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        employee.HireDate = DateTime.SpecifyKind(employee.HireDate, DateTimeKind.Utc);
        await _context.Employees.AddAsync(employee);
        return employee;
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        var find = await _context.Employees.FindAsync(employee.Id);
        if (find != null)
        {
            employee.HireDate = DateTime.SpecifyKind(employee.HireDate, DateTimeKind.Utc);
            find.FirstName = employee.FirstName;
            find.LastName = employee.LastName;
            find.Email = employee.Email;
            find.Phone = employee.Phone;
            find.HireDate = employee.HireDate;
            find.JobId = employee.JobId;
            find.Salary = employee.Salary;
            find.CommissionPct = employee.CommissionPct;
            find.ManagerId = employee.ManagerId;
            find.DepartmentId = employee.DepartmentId;
            await _context.SaveChangesAsync();
            return find;
        }

        return employee;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var find = await _context.Employees.FindAsync(id);
        if (find != null)
        {
            _context.Employees.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        var find = await _context.Employees.FindAsync(id);
        if (find != null)
        {
            return find;
        }
        return new Employee(){Id = id};
    }

    public async Task<List<Employee>> GetEmployees()
    {
        return await _context.Employees.ToListAsync();
    }
}