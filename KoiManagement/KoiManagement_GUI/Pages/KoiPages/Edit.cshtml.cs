using AutoMapper;
using KoiManagement_Service.IService;
using KoiManagement_Services.KoiServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.KoiPages
{
	public class EditModel : PageModel
	{
		private readonly IServiceManager serviceManager;
		private readonly IMapper mapper;

		public EditModel(IServiceManager serviceManager, IMapper mapper)
		{
			this.serviceManager = serviceManager;
			this.mapper = mapper;
		}

		[BindProperty]
		public KoiForUpdateDto Koi { get; set; } = default!;

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
			Koi = mapper.Map<KoiForUpdateDto>(koi);
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

			await serviceManager.KoiService.Update(Koi);

			return RedirectToPage("./Index");
		}

		private async Task<bool> KoiExists(string id, string userId)
		{
			return await serviceManager.KoiService.GetById(id, userId) is not null;
		}
	}
}
