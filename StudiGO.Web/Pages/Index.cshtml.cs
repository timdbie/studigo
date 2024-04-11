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

    public async Task OnGetAsync(string query)
    {
        if (!string.IsNullOrEmpty(query))
        {
            var stationsDto = await _stationsService.GetStationsAsync(query, "NL", 10);
            ViewData["Stations"] = stationsDto;
        }
    }
}