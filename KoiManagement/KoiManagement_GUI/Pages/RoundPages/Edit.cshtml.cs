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

namespace KoiManagement_GUI.Pages.RoundPages
{
    public class EditModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public EditModel(KoiManagement_DAO.KoiManagementContext context)
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

            var round =  await _context.Rounds.FirstOrDefaultAsync(m => m.Id == id);
            if (round == null)
            {
                return NotFound();
            }
            Round = round;
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

            _context.Attach(Round).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundExists(Round.Id))
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

        private bool RoundExists(string id)
        {
            return _context.Rounds.Any(e => e.Id == id);
        }
    }
}
