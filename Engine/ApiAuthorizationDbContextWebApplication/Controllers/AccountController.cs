using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiAuthorizationDbContextWebApplication.Persistence;
using Microsoft.AspNetCore.Identity;
using ApiAuthorizationDbContextWebApplication.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ApiAuthorizationDbContextWebApplication.Controllers
{
	//[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public AccountController(
			ApplicationDbContext dbContext,
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager
			)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		[HttpGet]
		public IActionResult Get()
		{
			// Access the database context and perform operations
			// For example, retrieve all users from the database
			var users = _dbContext.Users.ToList();

			return Ok(users);
		}
		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> Create([FromBody] UserDetails login)
		{
			try
			{
				// Create a new instance of IdentityUser or your custom ApplicationUser class
				var user = new ApplicationUser
				{
					UserName = login.Email,
					Email = login.Email
				};

				// Create an instance of UserManager<TUser> and RoleManager<TRole> by injecting them through DI or using a service locator
				//var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
				//var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

				// Use the UserManager<TUser> to create the new user
				var result = await _userManager.CreateAsync(user, login.Password);

				if (result.Succeeded)
				{
					// User created successfully
					// Access the user's properties via the ApplicationUser instance
					var userId = user.Id;
					var userName = user.UserName;

					// Add roles to the user
					await AddRolesToUser(user, _userManager, _roleManager);

					// Additional actions after creating the user
					return Ok(new { result, userId, userName });
				}
				else
				{
					// Failed to create the user
					// Handle the error, examine the result.Errors collection for details
					return Ok(new { result });
				}

			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private async Task AddRolesToUser(ApplicationUser user, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			// Check if the "Admin" role exists, if not, create it
			if (!await roleManager.RoleExistsAsync("Admin"))
			{
				await roleManager.CreateAsync(new IdentityRole("Admin"));
			}

			// Check if the "User" role exists, if not, create it
			if (!await roleManager.RoleExistsAsync("User"))
			{
				await roleManager.CreateAsync(new IdentityRole("User"));
			}

			// Assign the "Admin" role to the user
			await userManager.AddToRoleAsync(user, "Admin");

			// Assign the "User" role to the user
			await userManager.AddToRoleAsync(user, "User");
		}

		//[HttpPost]
		//public async Task<IActionResult> Create2([FromBody] UserDetails login)
		//{
		//	try
		//	{
		//		// Create a new instance of IdentityUser or your custom ApplicationUser class
		//		var user = new ApplicationUser
		//		{
		//			UserName = login.Email,
		//			Email = login.Email
		//		};

		//		// Create an instance of UserManager<TUser> by injecting it through DI or using a service locator
		//		//var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

		//		// Use the UserManager<TUser> to create the new user
		//		var result = await _userManager.CreateAsync(user, login.Password);

		//		if (result.Succeeded)
		//		{
		//			// User created successfully
		//			// Access the user's properties via the IdentityUser instance
		//			var userId = user.Id;
		//			var userName = user.UserName;

		//			// Additional actions after creating the user
		//			return Ok(new { result, userId, userName });
		//		}
		//		else
		//		{
		//			// Failed to create the user
		//			// Handle the error, examine the result.Errors collection for details
		//			return Ok(new { result });
		//		}

		//	}
		//	catch (Exception ex)
		//	{

		//		throw;
		//	}
		//}

		//[HttpPost]
		//public async Task<IActionResult> Login2(LoginViewModel model)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		// Attempt to sign in the user
		//		var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

		//		if (result.Succeeded)
		//		{
		//			// Sign-in successful, redirect to the desired page
		//			return RedirectToAction("Index", "Home");
		//		}

		//		if (result.IsLockedOut)
		//		{
		//			// Handle locked-out user
		//			return View("Lockout");
		//		}
		//		else
		//		{
		//			// Invalid sign-in attempt
		//			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
		//			return View(model);
		//		}
		//	}

		//	// If we reach here, the model is invalid, so redisplay the login view with validation errors
		//	return View(model);
		//}

		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

				if (result.Succeeded)
				{
					var user = await _userManager.FindByEmailAsync(model.Email);
					var token = GenerateJwtToken(user);

					// Return the bearer token
					return Ok(new { token });
				}

				if (result.IsLockedOut)
				{
					return BadRequest("Account locked out");
				}
			}

			return BadRequest("Invalid login attempt");
		}
		private string GenerateJwtToken(IdentityUser user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(/*"your-secret-key"*/"lNBFrk8xd+mYv1KKmYlZxZ25q60bDiibDZ1vFTUJz90="); // Replace with your secret key
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
			new Claim(ClaimTypes.NameIdentifier, user.Id),
			new Claim(ClaimTypes.Email, user.Email)
            // Add any additional claims as needed
        }),
				Expires = DateTime.UtcNow.AddDays(7), // Token expiration time
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

	}
}
