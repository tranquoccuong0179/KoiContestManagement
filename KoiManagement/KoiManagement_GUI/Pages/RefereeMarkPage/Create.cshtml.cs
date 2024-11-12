using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_GUI.Pages.RefereeMarkPage
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
        ViewData["CompetitionRoundId"] = new SelectList(_context.CompetitionRounds, "Id", "Id");
        ViewData["MarkId"] = new SelectList(_context.Marks, "Id", "Id");
        ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public RefereeMark RefereeMark { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RefereeMarks.Add(RefereeMark);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
