using Microsoft.AspNetCore.Mvc;

namespace THTR.Persist.Controllers;

[ApiController]
[Route("Persist")]
public class PersistController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("HealthCheck")]
    public IActionResult HealthCheck()
    {        
        return Json("System is up");
    }
}
