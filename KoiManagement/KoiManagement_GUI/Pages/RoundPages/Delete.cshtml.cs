using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_GUI.Pages.RoundPages
{
    public class DeleteModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public DeleteModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var round = await _context.Rounds.FindAsync(id);
            if (round != null)
            {
                Round = round;
                _context.Rounds.Remove(Round);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
