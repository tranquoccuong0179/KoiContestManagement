using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionPages
{
    public class IndexModel : PageModel
    {
        private readonly ICompetitionService _competitionService;

        public IndexModel(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        public IList<Competition> Competition { get; set; } = default!;

        public void OnGet()
        {
            Competition = _competitionService.GetCompetitions();
        }
    }
}
