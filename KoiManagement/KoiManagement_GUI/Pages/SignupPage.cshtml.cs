using KoiManagement_Service.IService;
using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages
{
	public class SignupPageModel : PageModel
	{
		private readonly IServiceManager serviceManager;
		[BindProperty]
		public UserForRegistrationDto UserForRegistration { get; set; }
		public SignupPageModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}
		public void OnGet()
		{

		}

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid) return Page();
			var result = await serviceManager.AuthenticationService.RegisterUser(UserForRegistration);
			if (result.Succeeded)
			{
				TempData["RegistrationResult"] = "Registration Successful";
				return RedirectToPage("/LoginPage");
			}
			return Page();
		}

	}
}
