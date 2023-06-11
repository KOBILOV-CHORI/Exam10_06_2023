using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobGradeController : ControllerBase
{
    private readonly JobGradeService _jobHistoryService;

    public JobGradeController(JobGradeService jobHistoryService)
    {
        _jobHistoryService = jobHistoryService;
    }

    [HttpPost("Add JobGrade")]
    public async Task<JobGrade> AddJobGrade([FromForm]JobGrade jobHistory)
    {
        return await _jobHistoryService.AddJobGrade(jobHistory);
    }

    [HttpPut("Update JobGrade")]
    public async Task<JobGrade> UpdateJobGrade([FromForm]JobGrade jobHistory)
    {
        return await _jobHistoryService.UpdateJobGrade(jobHistory);
    }

    [HttpDelete("Delete JobGrade")]
    public async Task<bool> DeleteJobGrade(string gradeLevel)
    {
        return await _jobHistoryService.DeleteJobGrade(gradeLevel);
    }
    
    [HttpGet("Get jobHistorys")]
    public async Task<List<JobGrade>> GetJobGrades()
    {
        return await _jobHistoryService.GetJobGrades();
    }
    [HttpGet("Get jobHistory by id")]
    public async Task<JobGrade> GetJobGradeById(string gradeLevel)
    {
        return await _jobHistoryService.GetJobGradeById(gradeLevel);
    }
}