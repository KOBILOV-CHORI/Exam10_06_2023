
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class LocationController : ControllerBase
{
    private readonly LocationService _locationService;

    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpPost("Add Location")]
    public async Task<Location> AddLocation([FromForm]Location location)
    {
        return await _locationService.AddLocation(location);
    }

    [HttpPut("Update Location")]
    public async Task<Location> UpdateLocation([FromForm]Location location)
    {
        return await _locationService.UpdateLocation(location);
    }

    [HttpDelete("Delete Location")]
    public async Task<bool> DeleteLocation(int id)
    {
        return await _locationService.Delete(id);
    }
    
    [HttpGet("Get locations")]
    public async Task<List<Location>> GetLocations()
    {
        return await _locationService.GetLocations();
    }
    [HttpGet("Get location by id")]
    public async Task<Location> GetLocationById(int id)
    {
        return await _locationService.GetLocationById(id);
    }
}