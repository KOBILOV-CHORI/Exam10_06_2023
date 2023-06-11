using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("Add Employee")]
    public async Task<Employee> AddEmployee([FromForm]Employee employee)
    {
        return await _employeeService.AddEmployee(employee);
    }

    [HttpPut("Update Employee")]
    public async Task<Employee> UpdateEmployee([FromForm]Employee employee)
    {
        return await _employeeService.UpdateEmployee(employee);
    }

    [HttpDelete("Delete Employee")]
    public async Task<bool> DeleteEmployee(int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }
    
    [HttpGet("Get employees")]
    public async Task<List<Employee>> GetEmployees()
    {
        return await _employeeService.GetEmployees();
    }
    [HttpGet("Get employee by id")]
    public async Task<Employee> GetEmployeeById(int id)
    {
        return await _employeeService.GetEmployeeById(id);
    }
}