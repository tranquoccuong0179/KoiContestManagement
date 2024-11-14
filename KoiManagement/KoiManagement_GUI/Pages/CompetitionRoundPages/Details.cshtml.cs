using KoiManagement_BusinessObjects;
using KoiManagement_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using KoiManagement_Services.IService;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiService _koiService;

        public DetailsModel(IKoiService koiService)
        {
            _koiService = koiService;
        }

        public Koi Koi { get; set; }

        public IActionResult OnGet(string koiId)
        {
            if (string.IsNullOrEmpty(koiId))
            {
                return NotFound();
            }

            Koi = _koiService.GetKoiById(koiId);

            if (Koi == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
