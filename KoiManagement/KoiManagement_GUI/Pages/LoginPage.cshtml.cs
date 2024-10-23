using KoiManagement_BusinessObjects.Constants;
using KoiManagement_Service.IService;
using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages
{
	public class LoginPageModel : PageModel
	{
		private readonly IServiceManager serviceManager;
		[BindProperty]
		public UserForAuthenticationDto UserForAuthenticationDto { get; set; }
		public LoginPageModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}
		public void OnGet()
		{
			string registrationResult = TempData["RegistrationResult"] as string;
			if (!string.IsNullOrEmpty(registrationResult))
			{
				ViewData["RegistrationResult"] = registrationResult;
			}
		}

		public async Task<IActionResult> OnPost()
		{
			var user = await serviceManager.AuthenticationService.AuthenticateUser(UserForAuthenticationDto);
			if (user is not null)
			{
				HttpContext.Session.SetString("Id", user.Id);
				HttpContext.Session.SetString("FullName", user.FullName);
				if (user.Roles.Contains(Role.Admin))
				{
					HttpContext.Session.SetString("Role", Role.Admin);
				}
				else if (user.Roles.Contains(Role.Manager))
				{
					HttpContext.Session.SetString("Role", Role.Manager);
				}
				else if (user.Roles.Contains(Role.Referee))
				{
					HttpContext.Session.SetString("Role", Role.Referee);
				}
				else
				{
					HttpContext.Session.SetString("Role", Role.Constestant);
				}
				ViewData["LoginResult"] = HttpContext.Session.GetString("Role");
				return Page();
			}
			else
			{
				ViewData["LoginResult"] = "Invalid username or password";
				return Page();
			}
		}
	}
}
