using KoiManagement_Service.IService;
using KoiManagement_Services.KoiServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.KoiPages
{
	public class CreateModel : PageModel
	{
		private readonly IServiceManager serviceManager;

		public CreateModel(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public void OnGet()
		{

		}

		[BindProperty]
		public KoiForCreationDto Koi { get; set; } = default!;

		// For more information, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			await serviceManager.KoiService.Create(Koi);

			return RedirectToPage("./Index");
		}
	}
}
