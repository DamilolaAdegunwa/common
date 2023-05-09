using Microsoft.AspNetCore.Mvc;

namespace MongoMission.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet, Route("ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok("up and running!!");
        }
    }
}