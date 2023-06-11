using System.ComponentModel.DataAnnotations;

namespace ApiAuthorizationDbContextWebApplication.Models
{
	public class LoginViewModel
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
	public class UserDetails
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}

}
