using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudiGO.Core.Services;
using StudiGO.Core.DTOs;

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
    
    public TripsDto Trips { get; private set; }
    
    public async Task<IActionResult> OnGetAsync(string fromStation, string toStation, string date, string time)
    {
        if (Request.Method == "GET" && !string.IsNullOrEmpty(fromStation) && !string.IsNullOrEmpty(toStation) && !string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(time))
        {
            string dateTime = date + "T" + time;
            Trips = await _tripsService.GetTripsAsync(fromStation, toStation, dateTime);
        }
    
        return Page();
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
}