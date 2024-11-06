using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
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
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
        ViewData["CompetitionId"] = new SelectList(_context.Competitions, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CompetitionCategory CompetitionCategory { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CompetitionCategories.Add(CompetitionCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
