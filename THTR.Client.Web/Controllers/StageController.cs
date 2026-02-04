using Microsoft.AspNetCore.Mvc;

namespace THTR.Client.Web.Controllers
{
    [ApiController]
    [Route("Stage")]
    public class StageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
