using KoiManagement_Service.IService;
using KoiManagement_Services.KoiServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.KoiPages
{
	public class DeleteModel : PageModel
	{
		private readonly IServiceManager serviceManager;

		public DeleteModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[BindProperty]
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

		public async Task<IActionResult> OnPostAsync(string id, string userId)
		{
			if (id == null)
			{
				return NotFound();
			}

			var koi = await serviceManager.KoiService.GetById(id, userId);
			if (koi != null)
			{
				Koi = koi;
				await serviceManager.KoiService.Delete(userId, id);
			}

			return RedirectToPage("./Index");
		}
	}
}
