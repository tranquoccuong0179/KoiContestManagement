using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionPages
{
    public class CreateModel : PageModel
    {
        private readonly ICompetitionService _competitionService;

        public CreateModel(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Competition Competition { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _competitionService.AddCompetition(Competition);

            // Assuming Competition.Id has been generated after saving
            return RedirectToPage("/CompetitionCategoryPages/Create", new { competitionId = Competition.Id });
        }

    }
}
