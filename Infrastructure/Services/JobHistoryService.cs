using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobHistoryService
{
    private readonly DataContext _context;

    public JobHistoryService(DataContext context)
    {
        _context = context;
    }

    public async Task<JobHistory> AddJobHistory(JobHistory jobHistory)
    {
        await _context.JobsHistories.AddAsync(jobHistory);
        await _context.SaveChangesAsync();
        return jobHistory;
    }

    public async Task<JobHistory> UpdateJobHistory(JobHistory jobHistory)
    {
        var find = await _context.JobsHistories.FindAsync(jobHistory.EmployeeId);
        if (find != null)
        {
            find.StartDate = jobHistory.StartDate;
            find.EndDate = jobHistory.EndDate;
            find.JobId = jobHistory.JobId;
            find.DepartmentId = jobHistory.DepartmentId;
            await _context.SaveChangesAsync();
            return find;
        }
        return jobHistory;
    }

    public async Task<bool> DeleteJobHistory(int id)
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

    public async Task<JobHistory> GetJobHistoryById(int employeeId)
    {
        var find = await _context.JobsHistories.FindAsync(employeeId);
        if (find != null)
        {
            return find;
        }
        return new JobHistory(){EmployeeId = employeeId};
    }

    public async Task<List<JobHistory>> GetJobsHistories()
    {
        return await _context.JobsHistories.ToListAsync();
    }
}