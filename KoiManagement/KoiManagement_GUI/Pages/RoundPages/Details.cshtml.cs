using KoiManagement_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.RoundPages
{
    public class DetailsModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public DetailsModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

        public Round Round { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var round = await _context.Rounds.FirstOrDefaultAsync(m => m.Id == id);
            if (round == null)
            {
                return NotFound();
            }
            else
            {
                Round = round;
            }
            return Page();
        }
    }
}
