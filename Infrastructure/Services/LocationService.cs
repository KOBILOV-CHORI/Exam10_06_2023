using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class LocationService
{
    private readonly DataContext _context;

    public LocationService(DataContext context)
    {
        _context = context;
    }

    public async Task<Location> AddLocation(Location location)
    {
        await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();
        return location;
    }

    public async Task<Location> UpdateLocation(Location location)
    {
        var find = await _context.Locations.FindAsync(location.Id);
        if (find != null)
        {
            find.StreetAddress = location.StreetAddress;
            find.PostalCode = location.PostalCode;
            find.City = location.City;
            find.StateProvince = location.StateProvince;
            find.CountryId = location.CountryId;
            await _context.SaveChangesAsync();
            return find;
        }
        return new Location();
    }

    public async Task<bool> Delete(int id)
    {
        var find = await _context.Locations.FindAsync(id);
        if (find != null)
        {
            _context.Locations.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Location> GetLocationById(int id)
    {
        var find = await _context.Locations.FindAsync(id);
        if (find != null)
        {
            return find;
        }
        return new Location(){Id = id};
    }

    public async Task<List<Location>> GetLocations()
    {
        return await _context.Locations.ToListAsync();
    }
}
