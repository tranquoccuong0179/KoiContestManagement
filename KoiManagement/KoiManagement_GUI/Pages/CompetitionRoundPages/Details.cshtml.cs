using KoiManagement_BusinessObjects;
using KoiManagement_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiService _koiService;

        private readonly ICompetitionRoundService _competitionRoundService;
        public DetailsModel(IKoiService koiService, ICompetitionRoundService competitionRoundService)
        {
            _koiService = koiService;
            _competitionRoundService = competitionRoundService;
        }

        public Koi Koi { get; set; }

        public IActionResult OnGet(string koiId, string roundId, string competitionCategoryId)
        {
            if (string.IsNullOrEmpty(koiId))
            {
                return NotFound();
            }

            Koi = _koiService.GetKoiById(koiId);
            KoiId = koiId;
            RoundId = roundId;
            CompetitionCategoryId = competitionCategoryId;

            if (Koi == null)
            {
                return NotFound();
            }

            return Page();
        }


        [BindProperty]
        public string KoiId { get; set; }

        [BindProperty]
        public string RoundId { get; set; }

        [BindProperty]
        public string CompetitionCategoryId { get; set; }

        public IActionResult OnPostGoToRefereeMarkPage()
        {
            // Retrieve CompetitionRoundId based on KoiId, RoundId, and CompetitionCategoryId
            var competitionRoundId = _competitionRoundService.GetCompetitionRoundId(KoiId, RoundId, CompetitionCategoryId);

            if (competitionRoundId == null)
            {
                ModelState.AddModelError(string.Empty, "Could not find the specified Competition Round.");
                return Page();
            }

          
            return RedirectToPage("/RefereeMarkPages/Create", new { competitionRoundId = competitionRoundId });
        }
    }
    
}
