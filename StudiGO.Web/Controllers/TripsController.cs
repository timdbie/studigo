using Microsoft.AspNetCore.Mvc;
using StudiGO.Core.Services;
using StudiGO.Web.Models;

namespace StudiGO.Web.Controllers;

public class TripsController : Controller
{
    private readonly TripsService _tripsService;

    public TripsController(TripsService tripsService)
    {
        _tripsService = tripsService;
    }

    public async Task<IActionResult> Index(string fromStation, string toStation, string dateTime)
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

        return PartialView("_TripsPartial", trips);
    }
}