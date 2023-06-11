using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _departmentService;

    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpPost("Add Department")]
    public async Task<Department> AddDepartment([FromForm]Department department)
    {
        return await _departmentService.AddDepartment(department);
    }

    [HttpPut("Update Department")]
    public async Task<Department> UpdateDepartment([FromForm]Department department)
    {
        return await _departmentService.UpdateDepartment(department);
    }

    [HttpDelete("Delete Department")]
    public async Task<bool> DeleteDepartment(int id)
    {
        return await _departmentService.Delete(id);
    }
    
    [HttpGet("Get departments")]
    public async Task<List<Department>> GetDepartments()
    {
        return await _departmentService.GetDepartments();
    }
    [HttpGet("Get department by id")]
    public async Task<Department> GetDepartmentById(int id)
    {
        return await _departmentService.GetDepartmentById(id);
    }
}