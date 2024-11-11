using KoiManagement_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionPages
{
    public class CreateModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public CreateModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
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

            _context.Competitions.Add(Competition);
            await _context.SaveChangesAsync();

            // Assuming Competition.Id has been generated after saving
            return RedirectToPage("/CompetitionCategoryPages/Create", new { competitionId = Competition.Id });
        }

    }
}
