using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EpsiVal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "ServicePolicy")]
    public class MyController : ControllerBase
    {
        [HttpGet]
        public IActionResult MyAction()
        {
            // Ваш код
        }
    }
}
