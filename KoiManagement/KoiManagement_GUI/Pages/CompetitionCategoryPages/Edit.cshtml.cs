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

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
{
    public class EditModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public EditModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CompetitionCategory CompetitionCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitioncategory =  await _context.CompetitionCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (competitioncategory == null)
            {
                return NotFound();
            }
            CompetitionCategory = competitioncategory;
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
           ViewData["CompetitionId"] = new SelectList(_context.Competitions, "Id", "Id");
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

            _context.Attach(CompetitionCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionCategoryExists(CompetitionCategory.Id))
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

        private bool CompetitionCategoryExists(string id)
        {
            return _context.CompetitionCategories.Any(e => e.Id == id);
        }
    }
}
