using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;
using THTR.Common.Models;
using Dapper;

namespace THTR.Persist.Controllers;

[ApiController]
[Route("Persist")]
public class PersistController(IOptions<THTRPersistOptions> options, IDbConnection db_conn) : Controller
{
    THTRPersistOptions _options = options.Value;
    IDbConnection _db_conn = db_conn;
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("HealthCheck")]
    public IActionResult HealthCheck()
    {
        try
        {
            _db_conn.Open();
            // Execute Scalar returns a single value (the '1' from our query)
            var result = _db_conn.ExecuteScalar<int>("SELECT 1");
            return Json("System is up, got a result from PostGres!");
        }
        catch(Exception ex)
        {
            return Json($"Im here but I can't reach PostGres: {ex.Message}");
        }

        
    }
}
