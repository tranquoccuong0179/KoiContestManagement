using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.CompetitionPages
{
    public class DeleteModel : PageModel
    {
        private readonly ICompetitionService _competitionService;

        public DeleteModel(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        [BindProperty]
        public Competition Competition { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = _competitionService.GetCompetition(id);

            if (competition == null)
            {
                return NotFound();
            }
            else
            {
                Competition = competition;
            }
            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = _competitionService.GetCompetition(id);
            if (competition != null)
            {
                Competition = competition;
                _competitionService.DeleteCompetition(competition);
            }
            return RedirectToPage("./Index");
        }
    }
}
