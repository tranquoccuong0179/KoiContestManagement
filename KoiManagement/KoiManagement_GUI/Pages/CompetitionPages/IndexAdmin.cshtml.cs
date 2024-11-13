using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionPages
{
    public class IndexAdminModel : PageModel
    {
        private readonly ICompetitionService _competitionService;

        public IndexAdminModel(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        public IList<Competition> Competition { get; set; } = default!;

        public void OnGet()
        {
            Competition = _competitionService.GetCompetitions();
        }
        public IActionResult OnPostDelete(string id)
        {
            var competition = _competitionService.GetCompetition(id);
            if (competition != null)
            {
                _competitionService.DeleteCompetition(competition);
            }
            return RedirectToPage(); // After deletion, redirect back to the same page
        }
    }
}
