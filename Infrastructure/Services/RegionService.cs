using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RegionService
{
    private readonly DataContext _context;

    public RegionService(DataContext context)
    {
        _context = context;
    }

    public async Task<Region> AddRegion(Region region)
    {
        await _context.Regions.AddAsync(region);
        await _context.SaveChangesAsync();
        return region;
    }

    public async Task<Region> UpdateRegion(Region region)
    {
        var find = await _context.Regions.FindAsync(region.Id);
        if (find != null)
        {
            find.RegionName = region.RegionName;
            await _context.SaveChangesAsync();
            return find;
        }
        return region;
    }

    public async Task<bool> DeleteRegion(int id)
    {
        var find = await _context.Regions.FindAsync(id);
        if (find != null)
        {
            _context.Regions.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Region> GetRegionById(int id)
    {
        var find = await _context.Regions.FindAsync(id);
        if (find != null)
        {
            return find;
        }
        return new Region(){Id = id};
    }

    public async Task<List<Region>> GetRegions()
    {
        return await _context.Regions.ToListAsync();
    }
}