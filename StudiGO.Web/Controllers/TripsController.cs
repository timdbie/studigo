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

        TripsViewModel tripsViewModel = TripsViewModel.FromDto(tripsDto);

        foreach (var trip in tripsViewModel.Trips)
        {
            string refUrl = $"#/?fromStation={fromStation}&toStation={toStation}&dateTime={dateTime}";
            trip.Ref = refUrl;
        }

        return PartialView("_TripsPartial", tripsViewModel);
    }
}