using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class EditModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public EditModel(KoiManagement_DAO.KoiManagementContext context)
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

            var competitionround =  await _context.CompetitionRounds.FirstOrDefaultAsync(m => m.Id == id);
            if (competitionround == null)
            {
                return NotFound();
            }
            CompetitionRound = competitionround;
           ViewData["CompetitionId"] = new SelectList(_context.Competitions, "Id", "Id");
           ViewData["KoiId"] = new SelectList(_context.Kois, "Id", "Id");
           ViewData["RoundId"] = new SelectList(_context.Rounds, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CompetitionRound).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionRoundExists(CompetitionRound.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompetitionRoundExists(string id)
        {
            return _context.CompetitionRounds.Any(e => e.Id == id);
        }
    }
}
