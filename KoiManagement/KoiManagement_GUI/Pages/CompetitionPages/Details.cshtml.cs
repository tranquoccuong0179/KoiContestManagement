using KoiManagement_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.CompetitionPages
{
    public class DetailsModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public DetailsModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

        public Competition Competition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _context.Competitions.FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
