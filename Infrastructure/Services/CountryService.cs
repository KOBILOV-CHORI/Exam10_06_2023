using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CountryService
{
    private readonly DataContext _context;

    public CountryService(DataContext context)
    {
        _context = context;
    }

    public async Task<Country> AddCountry(Country country)
    {
        await _context.Countries.AddAsync(country);
        await _context.SaveChangesAsync();
        return country;
    }

    public async Task<Country> UpdateCountry(Country country)
    {
        var find = await _context.Countries.FindAsync(country.Id);
        if (find != null)
        {
            find.CountryName = country.CountryName;
            find.RegionId = country.RegionId;
            await _context.SaveChangesAsync();
            return find;
        }
        return new Country(){Id = country.Id};
    }

    public async Task<bool> Delete(int id)
    {
        var find = await _context.Countries.FindAsync(id);
        if (find != null)
        {
            _context.Countries.Remove(find);
            await _context.SaveChangesAsync();
            return true ;
        }

        return false;
    }

    public async Task<Country> GetCountryById(int id)
    {
        var find = await _context.Countries.FindAsync(id);
        if (find != null)
        {
            return find;
        }

        return new Country(){Id = id};
    }

    public async Task<List<Country>> GetCountries()
    {
        return await _context.Countries.ToListAsync();
    }
}