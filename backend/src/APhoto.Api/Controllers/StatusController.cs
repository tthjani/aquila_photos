using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace APhoto.Api.Controllers
{
    [AllowAnonymous]
    public class StatusController : Controller
    {
        [HttpGet]
        [Route("/version")]
        public IActionResult Version()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version!;
            return Ok(version.ToString());
        }

        [HttpGet]
        [Route("/ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}
