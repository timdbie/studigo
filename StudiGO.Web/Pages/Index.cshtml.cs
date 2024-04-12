using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudiGO.Core.Services;

namespace StudiGO.Pages;

public class IndexModel : PageModel
{
    private readonly StationsService _stationsService;

    public IndexModel(StationsService stationsService)
    {
        _stationsService = stationsService;
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