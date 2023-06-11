using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class DepartmentService
{
    private readonly DataContext _context;

    public DepartmentService(DataContext context)
    {
        _context = context;
    }

    public async Task<Department> AddDepartment(Department department)
    {
        await _context.Departments.AddAsync(department);
        return department;
    }

    public async Task<Department> UpdateDepartment(Department department)
    {
        var find = await _context.Departments.FindAsync(department.Id);
        if (find != null)
        {
            find.DepartmentName = department.DepartmentName;
            find.LocationId = department.LocationId;
            await _context.SaveChangesAsync();
            return find;
        }

        return new Department(){Id = department.Id};
    }

    public async Task<bool> Delete(int id)
    {
        var find = await _context.Departments.FindAsync(id);
        if (find != null)
        {
            _context.Departments.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Department> GetDepartmentById(int id)
    {
        var find = await _context.Departments.FindAsync(id);
        if (find != null)
        {
            return find;
        }
        return new Department(){Id = id};
    }

    public async Task<List<Department>> GetDepartments()
    {
        return await _context.Departments.ToListAsync();
    }
}