using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class DeleteModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public DeleteModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CompetitionRound CompetitionRound { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitionround = await _context.CompetitionRounds.FirstOrDefaultAsync(m => m.Id == id);

            if (competitionround == null)
            {
                return NotFound();
            }
            else
            {
                CompetitionRound = competitionround;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitionround = await _context.CompetitionRounds.FindAsync(id);
            if (competitionround != null)
            {
                CompetitionRound = competitionround;
                _context.CompetitionRounds.Remove(CompetitionRound);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
