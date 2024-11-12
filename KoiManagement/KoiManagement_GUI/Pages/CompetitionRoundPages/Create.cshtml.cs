using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
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
        ViewData["CompetitionId"] = new SelectList(_context.Competitions, "Id", "Id");
        ViewData["KoiId"] = new SelectList(_context.Kois, "Id", "Id");
        ViewData["RoundId"] = new SelectList(_context.Rounds, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CompetitionRound CompetitionRound { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CompetitionRounds.Add(CompetitionRound);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
