using KoiManagement_Service.IService;
using KoiManagement_Services.KoiServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.KoiPages
{
	public class DetailsModel : PageModel
	{
		private readonly IServiceManager serviceManager;

		public DetailsModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public KoiForReturnDto Koi { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id, string userId)
		{
			if (id == null)
			{
				return NotFound();
			}

			var koi = await serviceManager.KoiService.GetById(id, userId);
			if (koi == null)
			{
				return NotFound();
			}
			else
			{
				Koi = koi;
			}
			return Page();
		}
	}
}
