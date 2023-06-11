using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobController : ControllerBase
{
    private readonly JobService _jobService;

    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }

    [HttpPost("Add Job")]
    public async Task<Job> AddJob([FromForm]Job job)
    {
        return await _jobService.AddJob(job);
    }

    [HttpPut("Update Job")]
    public async Task<Job> UpdateJob([FromForm]Job job)
    {
        return await _jobService.UpdateJob(job);
    }

    [HttpDelete("Delete Job")]
    public async Task<bool> DeleteJob(int id)
    {
        return await _jobService.DeleteJob(id);
    }
    
    [HttpGet("Get jobs")]
    public async Task<List<Job>> GetJobs()
    {
        return await _jobService.GetJobs();
    }
    [HttpGet("Get job by id")]
    public async Task<Job> GetJobById(int id)
    {
        return await _jobService.GetJobById(id);
    }
}