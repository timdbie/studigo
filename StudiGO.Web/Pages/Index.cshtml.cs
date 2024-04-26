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
    
    public async Task<IActionResult> OnGetTripsAsync(string fromStation, string toStation, string dateTime) 
    {
        var tripsDto = await _tripsService.GetTripsAsync(fromStation, toStation, dateTime);
        
        List<TripViewModel> trips = new List<TripViewModel>();    
        
        foreach (var trip in tripsDto.Trips)
        {
            string refUrl = $"#/?fromStation={fromStation}&toStation={toStation}&dateTime={dateTime}";

            TripViewModel tripViewModel = TripViewModel.FromDto(trip);
            tripViewModel.Ref = refUrl;
        
            trips.Add(tripViewModel);
        }

        return Partial("_TripsPartial", trips);
    }
    
    public async Task<IActionResult> OnGetTripDetailsAsync(string context)
    {
        var singleTripDto = await _singleTripService.GetSingleTripAsync(context);
        
        TripDetailsViewModel tripDetails = TripDetailsViewModel.FromDto(singleTripDto);

        return Partial("_TripDetailsPartial", tripDetails);
    }
    
    public async Task<IActionResult> OnGetStationsAsync(string query)
    {
        if (!string.IsNullOrEmpty(query))
        {
            var stationsDto = await _stationsService.GetFilteredStationsAsync(query, "NL", 10);
            return Partial("_StationsPartial", stationsDto);
        }
        
        return BadRequest("Invalid query.");
    }
}