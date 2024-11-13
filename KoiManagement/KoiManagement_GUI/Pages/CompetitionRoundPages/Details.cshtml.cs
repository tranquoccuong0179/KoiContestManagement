using KoiManagement_BusinessObjects;
using KoiManagement_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class DetailsModel : PageModel
    {
        private readonly IServiceManager _serviceManager;

        public DetailsModel(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public Koi Koi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            // Check if user session exists, redirect to login if not
            var userId = HttpContext.Session.GetString("Id");
            if (userId == null)
            {
                return RedirectToPage("/LoginPage");
            }

            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            // Retrieve Koi details with user ID for access control
            Koi = await _serviceManager.KoiService.GetById(id, userId);
            if (Koi == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
