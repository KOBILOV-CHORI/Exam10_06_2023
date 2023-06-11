using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobHistoryController : ControllerBase
{
    private readonly JobHistoryService _jobHistoryService;

    public JobHistoryController(JobHistoryService jobHistoryService)
    {
        _jobHistoryService = jobHistoryService;
    }

    [HttpPost("Add JobHistory")]
    public async Task<JobHistory> AddJobHistory([FromForm]JobHistory jobHistory)
    {
        return await _jobHistoryService.AddJobHistory(jobHistory);
    }

    [HttpPut("Update JobHistory")]
    public async Task<JobHistory> UpdateJobHistory([FromForm]JobHistory jobHistory)
    {
        return await _jobHistoryService.UpdateJobHistory(jobHistory);
    }

    [HttpDelete("Delete JobHistory")]
    public async Task<bool> DeleteJobHistory(int id)
    {
        return await _jobHistoryService.DeleteJobHistory(id);
    }
    
    [HttpGet("Get jobHistorys")]
    public async Task<List<JobHistory>> GetJobHistories()
    {
        return await _jobHistoryService.GetJobsHistories();
    }
    [HttpGet("Get jobHistory by id")]
    public async Task<JobHistory> GetJobHistoryById(int id)
    {
        return await _jobHistoryService.GetJobHistoryById(id);
    }
}