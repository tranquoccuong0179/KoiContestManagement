using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class ViewPointsModel : PageModel
    {
        private readonly ICompetitionRoundService _competitionRoundService;

        public ViewPointsModel(ICompetitionRoundService competitionRoundService)
        {
            _competitionRoundService = competitionRoundService;
        }

        public List<CompetitionRound> TopKois { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CompetitionCategoryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoundId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int KoiCount { get; set; } 

        public async Task OnGetAsync()
        {
            TopKois = await _competitionRoundService.GetTopCompetitionRoundsByAverageScore(CompetitionCategoryId, RoundId, KoiCount);
        }
    }
}
