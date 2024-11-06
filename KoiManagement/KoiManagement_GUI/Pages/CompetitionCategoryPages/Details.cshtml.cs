using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
{
    public class DetailsModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public DetailsModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

        public CompetitionCategory CompetitionCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitioncategory = await _context.CompetitionCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (competitioncategory == null)
            {
                return NotFound();
            }
            else
            {
                CompetitionCategory = competitioncategory;
            }
            return Page();
        }
    }
}
