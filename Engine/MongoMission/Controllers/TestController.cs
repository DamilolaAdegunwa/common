using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoMission.Core.Models.Collections;

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

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IResult GetById(int id)
		{
			object product = null;//_productContext.Products.Find(id);
			return product == null ? Results.NotFound() : Results.Ok(product);
		}

		//[HttpGet("{id}")]
		//public Results<NotFound, Ok<Product>> GetById2(int id)
		//{
		//	var product = new Product(); //_productContext.Products.Find(id);
		//	return product == null ? TypedResults.NotFound() : TypedResults.Ok(product);
		//}
	}
}