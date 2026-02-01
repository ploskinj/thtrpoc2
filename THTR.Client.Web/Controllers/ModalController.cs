using Microsoft.AspNetCore.Mvc;

namespace THTR.Client.Web.Controllers
{
    [ApiController]
    [Route("Modal")]
    public class ModalController : Controller
    {
        [HttpGet("Fetch/{key}")]
        public IActionResult Fetch(string key)
        {
            return PartialView(key);
        }
    }
}
