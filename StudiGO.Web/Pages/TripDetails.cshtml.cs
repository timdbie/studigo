using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudiGO.Core.Services;
using StudiGO.Models;

namespace StudiGO.Pages;

public class TripDetails : PageModel
{
    private readonly SingleTripService _singleTripService;
    
    public TripDetails(SingleTripService singleTripService)
    {
        _singleTripService = singleTripService;
    }

    public async Task<IActionResult> OnGetAsync(string context)
    {
        var singleTripDto = await _singleTripService.GetSingleTripAsync(context);
        
        TripDetailsViewModel singleTrip = TripDetailsViewModel.FromDto(singleTripDto);

        return Partial("Partials/_TripDetailsPartial", singleTrip);
    }
}