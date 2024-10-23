using KoiManagement_BusinessObjects;
using KoiManagement_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

		public async Task<IActionResult> OnPostAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var koi = await _context.Kois.FindAsync(id);
			if (koi != null)
			{
				Koi = koi;
				_context.Kois.Remove(Koi);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
