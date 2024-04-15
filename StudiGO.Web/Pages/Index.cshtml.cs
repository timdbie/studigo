using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudiGO.Core.Services;

namespace StudiGO.Pages;

public class IndexModel : PageModel
{
    private readonly StationsService _stationsService;
    private readonly TripsService _tripsService;

    public IndexModel(StationsService stationsService, TripsService tripsService)
    {
        _stationsService = stationsService;
        _tripsService = tripsService;
    }
    
    public async Task<IActionResult> OnGetStationsAsync(string query)
    {
        if (!string.IsNullOrEmpty(query))
        {
            var stationsDto = await _stationsService.GetFilteredStationsAsync(query, "NL", 10);
            return new JsonResult(stationsDto);
        }
        
        return BadRequest("Invalid query.");
    }
    
    public async Task<IActionResult> OnGetTripsAsync(string fromStation, string toStation, string dateTime)
    {
        var tripsDto = await _tripsService.GetTripsAsync(fromStation, toStation, dateTime);
        return new JsonResult(tripsDto);
    }
}