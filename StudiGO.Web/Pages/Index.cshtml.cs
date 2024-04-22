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

    private List<Trip> _trips { get; set; }
    public List<TripViewModel> Trips { get; private set; }

    public async Task<IActionResult> OnGetTripsAsync(string fromStation, string toStation, string date, string time)
    {
        string dateTime = date + "T" + time;
        
        TripsDto tripsDto = await _tripsService.GetTripsAsync(fromStation, toStation, dateTime);
        _trips = tripsDto.trips;

        Trips = new List<TripViewModel>();

        foreach (var trip in _trips)
        {
            string plannedDuration = @TimeSpan.FromMinutes(trip.PlannedDurationInMinutes).ToString(@"hh\:mm");
            string actualDuration = @TimeSpan.FromMinutes(trip.ActualDurationInMinutes).ToString(@"hh\:mm");
            string plannedDepartureTime = trip.Legs[0].Origin.PlannedDateTime.ToString("HH:mm");
            string plannedArrivalTime = trip.Legs[^1].Destination.PlannedDateTime.ToString("HH:mm");
            int transfers = trip.Transfers;

            var tripViewModel = new TripViewModel
            {
                PlannedDuration = plannedDuration,
                ActualDuration = actualDuration,
                PlannedDepartureTime = plannedDepartureTime,
                PlannedArrivalTime = plannedArrivalTime,
                Transfers =  transfers,
            };
            
            Trips.Add(tripViewModel);
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