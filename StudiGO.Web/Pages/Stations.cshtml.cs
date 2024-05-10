using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudiGO.Core.Services;

namespace StudiGO.Pages;

public class Stations : PageModel
{
    private readonly StationsService _stationsService;
    
    public Stations(StationsService stationsService)
    {
        _stationsService = stationsService;
    }

    public async Task<IActionResult> OnGetAsync(string query)
    {
        if (!string.IsNullOrEmpty(query))
        {
            var stationsDto = await _stationsService.GetFilteredStationsAsync(query, "NL", 10);
            return Partial("Partials/_StationsPartial", stationsDto);
        }
        
        return BadRequest("Invalid query.");
    }
}