using Microsoft.AspNetCore.Mvc;

namespace THTR.Client.Web.Controllers
{
    [ApiController]
    [Route("Dev")]
    public class DevController : Controller
    {
        [HttpGet("EditAvatarJson")]
        public IActionResult EditAvatarJson()
        {
            return View();
        }
    }
}
