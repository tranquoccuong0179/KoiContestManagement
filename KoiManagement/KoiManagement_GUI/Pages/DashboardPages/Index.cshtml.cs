using KoiManagement_BusinessObjects;
using KoiManagement_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.DashboardPages
{
	public class IndexModel : PageModel
	{
		private readonly IServiceManager serviceManager;

		public List<Koi> KoiList { get; set; }
		public IndexModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}
		public async Task<IActionResult> OnGet()
		{
			KoiList = await serviceManager.KoiService.GetAll();
			return Page();
		}
	}
}
