using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuthorizationDbContextWebApplication.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		[HttpGet]
		//[Authorize("AdminOnly")]
		[Authorize]
		public IActionResult GetAdminUsers()
		{
			// Only users with the "Admin" role can access this endpoint
			// Perform admin-specific logic here
			return Ok("Admin users");
		}

		[HttpGet("{id}")]
		//[Authorize("UserOnly")]
		[Authorize]
		public IActionResult GetUser(string id)
		{
			var usr = User;
			var identity = User.Identity;
			var claims = User.Claims;
			var name = User.Identity.Name;
			var req = Request;
			// Only users with the "User" role can access this endpoint
			// Perform user-specific logic here
			return Ok($"User with ID: {id}");
		}

		[HttpGet("public")]
		public IActionResult GetPublicData()
		{
			// This endpoint is publicly accessible to both authenticated and anonymous users
			// Perform public logic here
			return Ok("Public data");
		}
	}
}
