using Microsoft.AspNetCore.Mvc;

namespace StudiGO.Web.Controllers;

public class IndexController : Controller
{
    public IActionResult Index()
    {
        return View("~/Views/Index.cshtml");
    }
}