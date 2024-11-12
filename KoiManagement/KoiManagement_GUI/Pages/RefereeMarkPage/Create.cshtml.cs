using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;

namespace KoiManagement_GUI.Pages.RefereeMarkPage
{
    public class CreateModel : PageModel
    {
        private readonly ICompetitionRoundService competitionRoundService;
        private readonly IMarkService markService;
        private readonly IAuthenticationService authenticationService;
        private readonly IRefereeMarkService refereeMarkService;

        public CreateModel(ICompetitionRoundService competitionRoundService, IMarkService markService, IAuthenticationService authenticationService, IRefereeMarkService refereeMarkService)
        {
            this.competitionRoundService = competitionRoundService;
            this.markService = markService;
            this.authenticationService = authenticationService;
            this.refereeMarkService = refereeMarkService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["CompetitionRoundId"] = new SelectList(competitionRoundService.GetAll(), "Id", "Id");
            ViewData["MarkId"] = new SelectList(markService.GetMarks(), "Id", "Point");
            ViewData["UserId"] = new SelectList(await authenticationService.GetAllUsersExcepAdmin(), "Id", "FullName");
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

            refereeMarkService.AddRefereeMark(RefereeMark);

            return RedirectToPage("./Index");
        }
    }
}
