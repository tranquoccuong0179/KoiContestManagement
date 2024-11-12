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
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;

namespace KoiManagement_GUI.Pages.RefereeMarkPage
{
    public class EditModel : PageModel
    {
        private readonly ICompetitionRoundService competitionRoundService;
        private readonly IMarkService markService;
        private readonly IAuthenticationService authenticationService;
        private readonly IRefereeMarkService refereeMarkService;

        public EditModel(ICompetitionRoundService competitionRoundService, IMarkService markService, IAuthenticationService authenticationService, IRefereeMarkService refereeMarkService)
        {
            this.competitionRoundService = competitionRoundService;
            this.markService = markService;
            this.authenticationService = authenticationService;
            this.refereeMarkService = refereeMarkService;
        }

        [BindProperty]
        public RefereeMark RefereeMark { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereemark =  refereeMarkService.GetRefereeMark(id);
            if (refereemark == null)
            {
                return NotFound();
            }
            RefereeMark = refereemark;
            ViewData["CompetitionRoundId"] = new SelectList(competitionRoundService.GetAll(), "Id", "Id");
            ViewData["MarkId"] = new SelectList(markService.GetMarks(), "Id", "Point");
            ViewData["UserId"] = new SelectList(await authenticationService.GetAllUsersExcepAdmin(), "Id", "FullName");
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

            bool updateSuccess = refereeMarkService.UpdateRefereeMark(RefereeMark);

            if (!updateSuccess)
            {
                if (!RefereeMarkExists(RefereeMark.Id))
                {
                    return NotFound();
                }
                else
                {
                    // Throw exception hoặc ghi log nếu cần thiết
                    throw new DbUpdateConcurrencyException();
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RefereeMarkExists(string id)
        {
            return refereeMarkService.GetRefereeMark(id) != null;
        }
    }
}
