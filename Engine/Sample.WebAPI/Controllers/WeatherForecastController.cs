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
            //var files = System.Web.HttpContext.Current.Request.Files[0];
            var f2 = Request.HttpContext.Request.Form.Files[0];
            var f3 = Request.Form.Files[0];
            return Ok();
        }
    }
    public class TestModel
    {
        public IList<IFormFile> File { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        //public string Hobbies { get; set; }
        //public List<KeyValuePair<long,string>> Properties { get; set; }
    }
}
