using Microsoft.AspNetCore.Mvc;
using StudiGO.Core.Services;

namespace StudiGO.Web.Controllers;

public class StationsController : Controller
{
    private readonly StationsService _stationsService;

    public StationsController(StationsService stationsService)
    {
        _stationsService = stationsService;
    }

    public async Task<IActionResult> Index(string query)
    {
        if (!string.IsNullOrEmpty(query))
        {
            var stationsDto = await _stationsService.GetFilteredStationsAsync(query, 10);
            return PartialView("_StationsPartial", stationsDto);
        }
            
        return BadRequest("Invalid query.");
    }
}