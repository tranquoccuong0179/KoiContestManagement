using KoiManagement_BusinessObjects;
using KoiManagement_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.KoiPages
{
	public class DetailsModel : PageModel
	{
		private readonly IServiceManager serviceManager;

		public DetailsModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public Koi Koi { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var koi = await _context.Kois.FirstOrDefaultAsync(m => m.Id == id);
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
