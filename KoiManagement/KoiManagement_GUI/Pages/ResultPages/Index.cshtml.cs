using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.ResultPages
{
    public class IndexModel : PageModel
    {
        private readonly IResultService resultService;
        private readonly ICompetitionService competitionService;

        public IndexModel(IResultService resultService, ICompetitionService competitionService)
        {
            this.resultService = resultService;
            this.competitionService = competitionService;
        }

        public IList<Result> Result { get; set; } = default!;

        public async Task OnGetAsync(string competitionId)
        {
            var competition = competitionService.GetCompetition(competitionId);
            ViewData["CompetitionName"] = competition.Name;

            Result = resultService.GetResults();
        }
    }
}
