using KoiManagement_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.RoundPages
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
        public Round Round { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rounds.Add(Round);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
