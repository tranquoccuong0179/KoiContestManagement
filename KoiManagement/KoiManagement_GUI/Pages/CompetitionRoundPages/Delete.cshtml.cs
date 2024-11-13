using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class DeleteModel : PageModel
    {
        private readonly ICompetitionRoundService competitionRoundService;

        public DeleteModel(ICompetitionRoundService competitionRoundService)
        {
            this.competitionRoundService = competitionRoundService;
        }

        [BindProperty]
        public CompetitionRound CompetitionRound { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitionround = competitionRoundService.GetById(id);

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

            var competitionround = competitionRoundService.GetById(id);
            if (competitionround != null)
            {
                CompetitionRound = competitionround;
                competitionRoundService.DeleteCompetitionRound(competitionround);
            }

            return RedirectToPage("./Index");
        }
    }
}
