using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudiGO.Core.Services;
using StudiGO.Models;

namespace StudiGO.Pages;

public class Trips : PageModel
{
    private readonly TripsService _tripsService;
    
    public Trips(TripsService tripsService)
    {
        _tripsService = tripsService;
    }

    public async Task<IActionResult> OnGetAsync(string fromStation, string toStation, string dateTime)
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

        return Partial("Partials/_TripsPartial", trips);
    }
}