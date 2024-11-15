using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class IndexModel : PageModel
    {
        private readonly ICompetitionRoundService competitionRoundService;

        public IndexModel(ICompetitionRoundService competitionRoundService)
        {
            this.competitionRoundService = competitionRoundService;
        }

        public Dictionary<(CompetitionCategory CompetitionCategory, Round Round), List<Koi>> CompetitionRoundWithKoi { get; set; } = default!;

        public void OnGet(string competitionCategoryId, string roundId)
        {
            CompetitionRoundWithKoi = competitionRoundService.GetCompetitionRoundWithKoi(competitionCategoryId, roundId);

        }
        
    }
}

