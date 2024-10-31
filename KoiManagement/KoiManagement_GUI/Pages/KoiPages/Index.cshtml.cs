using KoiManagement_BusinessObjects;
using KoiManagement_Service.IService;
using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.KoiPages
{
	public class IndexModel : PageModel
	{
		private readonly IServiceManager serviceManager;

		[BindProperty]
		public UserForReturnDto UserForReturnDto { get; set; }

		public IndexModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public IList<Koi> Koi { get; set; } = default!;

		public async Task OnGetAsync()
		{
			string userId = HttpContext.Session.GetString("Id");
			UserForReturnDto = await serviceManager.AuthenticationService.GetUserById(userId);
			Koi = await serviceManager.KoiService.GetByUserIdActive(userId);
		}
	}
}
