using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using THTR.Client.Web.Models;
using THTR.Common.Models;
using THTR.Common.HttpClients;


namespace THTR.Client.Web.Controllers
{
    [Route("[controller]")]
    public class HomeController(IOptions<THTROptions> options, PersistHttpClient persist_client) : Controller
    {
        private readonly PersistHttpClient _persist_client = persist_client;
        private readonly THTROptions _options = options.Value;

        [HttpGet]
        [Route("~/")]      // This overrides the controller-level "Home" route for this action
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("HealthCheck")]
        public async Task<IActionResult> HealthCheck()
        {
            try
            {
                string persist_result = await _persist_client.health_check();
                return Json($"Persist: {persist_result}");

            }
            catch (Exception ex)
            {
                return Json($"Im working but Persist is not: {_options.PersistUrl} {ex.Message}");
            }            
        }
    }
}
