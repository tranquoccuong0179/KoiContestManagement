using KoiManagement_BusinessObjects;
using KoiManagement_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.KoiPages
{
    public class DetailsModel : PageModel
    {
        private readonly IServiceManager serviceManager;
        private string userId;

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
    }
}
