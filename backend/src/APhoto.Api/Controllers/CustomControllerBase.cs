using Microsoft.AspNetCore.Mvc;

namespace APhoto.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CustomControllerBase<T> : ControllerBase
        where T : CustomControllerBase<T>
    {
        protected ILogger<T> Logger;

        protected CustomControllerBase(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}
