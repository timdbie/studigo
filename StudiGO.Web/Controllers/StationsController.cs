using Microsoft.AspNetCore.Mvc;
using StudiGO.Core.Services;
using StudiGO.Web.Models;

namespace StudiGO.Web.Controllers;

public class StationsController : Controller
{
    private readonly StationsService _stationsService;

    public StationsController(StationsService stationsService)
    {
        _stationsService = stationsService;
    }

    public async Task<IActionResult> Index(string query)
    {
        var stationsDto = await _stationsService.GetFilteredStationsAsync(query);

        StationsViewModel stationsViewModel = StationsViewModel.FromDto(stationsDto);
        
        return PartialView("_StationsPartial", stationsViewModel);
    }
}