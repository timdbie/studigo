using Microsoft.AspNetCore.Mvc;
using StudiGO.Core.Services;
using StudiGO.Web.Models;

namespace StudiGO.Web.Controllers;

public class TripDetailsController : Controller
{
    private readonly SingleTripService _singleTripService;

    public TripDetailsController(SingleTripService singleTripService)
    {
        _singleTripService = singleTripService;
    }

    public async Task<IActionResult> Index(string context)
    {
        var singleTripDto = await _singleTripService.GetSingleTripAsync(context);

        TripDetailsViewModel singleTrip = TripDetailsViewModel.FromDto(singleTripDto);

        return PartialView("_TripDetailsPartial", singleTrip);
    }
}