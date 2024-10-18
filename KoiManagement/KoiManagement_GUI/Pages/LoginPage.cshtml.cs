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
				ViewData["LoginResult"] = user.FullName;
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
