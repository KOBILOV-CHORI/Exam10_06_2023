using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobGradeService
{
    private readonly DataContext _context;

    public JobGradeService(DataContext context)
    {
        _context = context;
    }

    public async Task<JobGrade> AddJobGrade(JobGrade jobGrade)
    {
        await _context.JobsGrades.AddAsync(jobGrade);
        return jobGrade;
    }

    public async Task<JobGrade> UpdateJobGrade(JobGrade jobGrade)
    {
        var find = await _context.JobsGrades.FindAsync(jobGrade.GradeLevel);
        if (find != null)
        {
            find.LowestSal = jobGrade.LowestSal;
            find.HighestSal = jobGrade.HighestSal;
            await _context.SaveChangesAsync();
            return find;
        }
        return jobGrade;
    }

    public async Task<bool> DeleteJobGrade(string gradeLevel)
    {
        var find = await _context.JobsGrades.FindAsync(gradeLevel);
        if (find != null)
        {
            _context.JobsGrades.Remove(find);
            await _context.SaveChangesAsync(); 
            return true;
        }

        return false;
    }

    public async Task<JobGrade> GetJobGradeById(string gradeLevel)
    {
        var find = await _context.JobsGrades.FindAsync(gradeLevel);
        if (find != null)
        {
            return find;
        }
        return new JobGrade(){GradeLevel = gradeLevel};
    }

    public async Task<List<JobGrade>> GetJobGrades()
    {
        return await _context.JobsGrades.ToListAsync();
    }
}