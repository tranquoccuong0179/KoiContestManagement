using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.Service;
using KoiManagement_Services.IService;


namespace KoiManagement_GUI.Pages.RefereeMarkPages
{
    public class CreateModel : PageModel
    {
        private readonly IRefereeMarkService refereeMarkService;
        private readonly IAuthenticationService authenticationService;
        private readonly IKoiService koiService;
        private readonly ICompetitionRoundService competitionRoundService;
        public CreateModel(IRefereeMarkService refereeMarkService, IAuthenticationService authenticationService, IKoiService koiService, ICompetitionRoundService competitionRoundService)
        {
            this.refereeMarkService = refereeMarkService;
            this.authenticationService = authenticationService;
            this.koiService = koiService;
            this.competitionRoundService = competitionRoundService;
        }


        public async Task<IActionResult> OnGet(string competitionRoundId)
        {
            ViewData["CompetitionRoundId"] = new SelectList(competitionRoundService.GetAll(), "Id", "Id");

            Task<List<Koi>> koiTask = koiService.GetAllWithKois(competitionRoundId);
            List<Koi> koiList = await koiTask;
            ViewData["KoiId"] = new SelectList(koiList, "Id", "Name");
            ViewData["UserId"] = new SelectList( await authenticationService.GetAllUsersExcepAdmin(), "Id", "FullName");

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
