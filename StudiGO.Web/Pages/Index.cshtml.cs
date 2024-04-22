using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudiGO.Core.Services;
using StudiGO.Core.DTOs;
using StudiGO.Models;

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

    private TripsDto _tripsDto { get; set; }
    public List<TripViewModel> Trips { get; private set; }

    public async Task<IActionResult> OnGetTripsAsync(string fromStation, string toStation, string date, string time)
    {
        string dateTime = date + "T" + time;
        
        _tripsDto = await _tripsService.GetTripsAsync(fromStation, toStation, dateTime);
        
        Trips = TripViewModel.FromDto(_tripsDto);

        return Page();
    }
    
    public async Task<IActionResult> OnGetTripDetailsAsync(int tripId)
    {
        TripDetailsViewModel tripDetails = TripDetailsViewModel.FromDto(_tripsDto, tripId);
        return new JsonResult(tripDetails);
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