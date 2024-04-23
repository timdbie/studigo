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
    private readonly SingleTripService _singleTripService;

    public IndexModel(StationsService stationsService, TripsService tripsService, SingleTripService singleTripService)
    {
        _stationsService = stationsService;
        _tripsService = tripsService;
        _singleTripService = singleTripService;
    }
    
    public List<TripViewModel> Trips { get; private set; }

    public async Task<IActionResult> OnGetTripsAsync(string fromStation, string toStation, string date, string time)
    {
        string dateTime = date + "T" + time;
        
        TripsDto tripsDto = await _tripsService.GetTripsAsync(fromStation, toStation, dateTime);
        
        Trips = new List<TripViewModel>();
        foreach (var trip in tripsDto.Trips)
        {
            TripViewModel tripViewModel = TripViewModel.FromDto(trip);
            Trips.Add(tripViewModel);
        }

        return Page();
    }
    
    public async Task<IActionResult> OnGetTripDetailsAsync(string context)
    {
        var singleTripDto = await _singleTripService.GetSingleTripAsync(context);
        
        TripDetailsViewModel tripDetails = TripDetailsViewModel.FromDto(singleTripDto);
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