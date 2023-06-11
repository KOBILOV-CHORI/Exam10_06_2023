using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class RegionController : ControllerBase
{
    private readonly RegionService _regionService;

    public RegionController(RegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpPost("Add Region")]
    public async Task<Region> AddRegion([FromForm]Region region)
    {
        return await _regionService.AddRegion(region);
    }

    [HttpPut("Update Region")]
    public async Task<Region> UpdateRegion([FromForm]Region region)
    {
        return await _regionService.UpdateRegion(region);
    }

    [HttpDelete("Delete Region")]
    public async Task<bool> DeleteRegion(int id)
    {
        return await _regionService.DeleteRegion(id);
    }
    
    [HttpGet("Get regions")]
    public async Task<List<Region>> GetRegions()
    {
        return await _regionService.GetRegions();
    }
    [HttpGet("Get region by id")]
    public async Task<Region> GetRegionById(int id)
    {
        return await _regionService.GetRegionById(id);
    }
}