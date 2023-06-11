using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CountryController : ControllerBase
{
    private readonly CountryService _countryService;

    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpPost("Add Country")]
    public async Task<Country> AddCountry([FromForm]Country country)
    {
        return await _countryService.AddCountry(country);
    }

    [HttpPut("Update Country")]
    public async Task<Country> UpdateCountry([FromForm]Country country)
    {
        return await _countryService.UpdateCountry(country);
    }

    [HttpDelete("Delete Country")]
    public async Task<bool> DeleteCountry(int id)
    {
        return await _countryService.Delete(id);
    }
    
    [HttpGet("Get countries")]
    public async Task<List<Country>> GetCountries()
    {
        return await _countryService.GetCountries();
    }
    [HttpGet("Get country by id")]
    public async Task<Country> GetCountryById(int id)
    {
        return await _countryService.GetCountryById(id);
    }
}