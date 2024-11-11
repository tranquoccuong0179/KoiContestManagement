using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiManagement_GUI.Pages.MarkPages
{
    public class CreateModel : PageModel
    {
        private readonly IMarkService markService;
        private readonly ICompetitionRoundService competitionRoundService;

        public CreateModel(IMarkService markService, ICompetitionRoundService competitionRoundService)
        {
            this.markService = markService;
            this.competitionRoundService = competitionRoundService;
        }

        public IActionResult OnGet()
        {
            ViewData["CompetitionRoundId"] = new SelectList(competitionRoundService.GetAll(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Mark Mark { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            markService.AddMark(Mark);

            return RedirectToPage("./Index");
        }
    }
}
