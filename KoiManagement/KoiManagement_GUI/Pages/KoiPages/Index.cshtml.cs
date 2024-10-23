using KoiManagement_Service.IService;
using KoiManagement_Services.KoiServices.DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.KoiPages
{
	public class IndexModel : PageModel
	{
		private readonly IServiceManager serviceManager;

		public IndexModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public IList<KoiForReturnDto> Koi { get; set; } = default!;

		public async Task OnGetAsync()
		{
			string userId = HttpContext.Session.GetString("Id");
			Koi = await serviceManager.KoiService.GetByUserId(userId);
		}
	}
}
