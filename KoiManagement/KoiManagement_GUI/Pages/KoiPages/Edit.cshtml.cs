using KoiManagement_BusinessObjects;
using KoiManagement_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.KoiPages
{
	public class EditModel : PageModel
	{
		private readonly IServiceManager serviceManager;

		public EditModel(IServiceManager serviceManager)
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
			Koi = koi;
			ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more information, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Koi).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!KoiExists(Koi.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool KoiExists(string id)
		{
			return _context.Kois.Any(e => e.Id == id);
		}
	}
}
