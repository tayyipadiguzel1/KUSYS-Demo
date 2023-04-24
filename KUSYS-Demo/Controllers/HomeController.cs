using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}