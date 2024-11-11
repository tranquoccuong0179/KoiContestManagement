using KoiManagement_Service.IService;
using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.ProfilePages
{
	public class UpdateProfilePageModel : PageModel
	{
		private readonly IServiceManager serviceManager;
		private string userId;

		[BindProperty]
		public UserForUpdateProfileDto UserForUpdateProfileDto { get; set; }
		public UpdateProfilePageModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}
		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			userId = HttpContext.Session.GetString("Id");
			var result = await serviceManager.AuthenticationService.UpdateUser(userId, UserForUpdateProfileDto);
			if (!result.Succeeded)
			{
				ViewData["ErrorMessage"] = "Something went wrong";
				return Page();
			}
			HttpContext.Session.SetString("FullName", UserForUpdateProfileDto.FullName);
			TempData["SuccessMessage"] = "Profile updated successfully";
			return RedirectToPage("/ProfilePages/Index");
		}
	}
}
