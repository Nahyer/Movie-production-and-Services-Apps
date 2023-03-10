using Microsoft.AspNetCore.Mvc;

namespace MoviesApp.Controllers
{
    public class RightsController : Controller
    {
        [HttpPost("api/Rights")]
        public IActionResult ValidateRights()
        {
            return Ok();
        }
    }
}
