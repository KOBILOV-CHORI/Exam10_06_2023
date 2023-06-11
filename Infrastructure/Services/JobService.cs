using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobService
{
    private readonly DataContext _context;

    public JobService(DataContext context)
    {
        _context = context;
    }

    public async Task<Job> AddJob(Job job)
    {
        await _context.Jobs.AddAsync(job);
        await _context.SaveChangesAsync();
        return job;
    }

    public async Task<Job> UpdateJob(Job job)
    {
        var find = await _context.Jobs.FindAsync(job.Id);
        if (find != null)
        {
            find.JobTitle = job.JobTitle;
            find.MinSalary = job.MinSalary;
            find.MaxSalary = job.MaxSalary;
            await _context.SaveChangesAsync();
            return find;
        }
        return job;
    }

    public async Task<bool> DeleteJob(int id)
    {
        var find = await _context.Jobs.FindAsync(id);
        if (find != null)
        {
            _context.Jobs.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Job> GetJobById(int id)
    {
        var find = await _context.Jobs.FindAsync(id);
        if (find != null)
        {
            return find;
        }
        return new Job(){Id = id};
    }

    public async Task<List<Job>> GetJobs()
    {
        return await _context.Jobs.ToListAsync();
    }
}