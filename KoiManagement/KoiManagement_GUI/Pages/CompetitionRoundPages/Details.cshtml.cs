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
    public class DetailsModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public DetailsModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

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
    }
}
