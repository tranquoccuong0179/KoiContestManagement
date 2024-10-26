using KoiManagement_Service.IService;
using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.ProfilePages
{
	public class IndexModel : PageModel
	{
		private string userId;
		private readonly IServiceManager serviceManager;

		[BindProperty]
		public UserForReturnDto User { get; set; } = default!;
		public IndexModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}
		public async Task<IActionResult> OnGetAsync()
		{
			userId = HttpContext.Session.GetString("Id");
			User = await serviceManager.AuthenticationService.GetUserById(userId);
			return Page();
		}
	}
}
