using KoiManagement_Service.IService;
using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.DashboardPages
{
	public class UsersModel : PageModel
	{
		private readonly IServiceManager serviceManager;

		public List<UserForReturnDto> Users { get; set; }
		public UsersModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}
		public async Task<IActionResult> OnGet()
		{
			Users = await serviceManager.AuthenticationService.GetAllUsersExcepAdmin();
			return Page();
		}

		public async Task<IActionResult> OnPost()
		{
			string id = Request.Form["id"];
			await serviceManager.AuthenticationService.UpdateActiveStatus(id);
			Users = await serviceManager.AuthenticationService.GetAllUsersExcepAdmin();
			return Page();
		}
	}
}
