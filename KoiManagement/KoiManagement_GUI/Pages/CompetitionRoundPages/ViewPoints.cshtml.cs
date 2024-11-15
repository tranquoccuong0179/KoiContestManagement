using KoiManagement_BusinessObjects;
using KoiManagement_DAO.DTO;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class ViewPointsModel : PageModel
    {
        private readonly ICompetitionRoundService _competitionRoundService;
        private readonly IRefereeMarkService _refereeMarkService;

        public ViewPointsModel(ICompetitionRoundService competitionRoundService, IRefereeMarkService refereeMarkService)
        {
            _competitionRoundService = competitionRoundService;
            _refereeMarkService = refereeMarkService;
        }

        public List<CompetitionRoundScore> TopKois { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string CompetitionCategoryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoundId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int KoiCount { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(CompetitionCategoryId) || string.IsNullOrEmpty(RoundId))
            {
                return NotFound();
            }

            TopKois = _refereeMarkService.GetTopCompetitionRoundScoreByCRIdnRId(CompetitionCategoryId, RoundId, KoiCount);

            return Page();
        }
    }
}