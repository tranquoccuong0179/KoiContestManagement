using KoiManagement_BusinessObjects;
using KoiManagement_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.KoiPages
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceManager serviceManager;
        private string userId;

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
            userId = HttpContext.Session.GetString("Id");

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            userId = HttpContext.Session.GetString("Id");

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
