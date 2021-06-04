using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public async Task<ActionResult> UploadTest([FromForm] TestModel test)
        {
            return Ok();
        }
    }
    public class TestModel
    {
        public IList<IFormFile> File { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Hobbies { get; set; }
    }
}
