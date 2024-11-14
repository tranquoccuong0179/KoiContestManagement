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

namespace KoiManagement_GUI.Pages.RegistrationPages
{
    public class EditModel : PageModel
    {
        private readonly IRegistrationService registrationService;
        private readonly IKoiService koiService;
        private readonly ICompetitionCategoryService competitionCategoryService;
        private readonly ICompetitionRoundService competitionRoundService;
        public EditModel(IRegistrationService registrationService, IKoiService koiService, ICompetitionCategoryService competitionCategoryService, ICompetitionRoundService competitionRoundService)
        {
            this.registrationService = registrationService;
            this.koiService = koiService;
            this.competitionCategoryService = competitionCategoryService;
            this.competitionRoundService = competitionRoundService;
        }

        [BindProperty]
        public Registration Registration { get; set; } = default!;

        bool wasCheckIn = false;
        public async Task<IActionResult> OnGetAsync(string id, string competitionid)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await  registrationService.GetRegistrationById(id);
            wasCheckIn = registration.IsCheckIn;
            if (registration == null)
            {
                return NotFound();
            }
            Registration = registration;
            
            string userId = registrationService.GetUserIdByKoiId(registration.KoiId);

            var competitionCategories = competitionCategoryService.GetCompetitionCategoryByCompetitionId(competitionid);
            ViewData["CompetitionCategoryId"] = new SelectList(competitionCategories, "Id", "CategoryName");
            Task<List<Koi>> koiTask = koiService.GetByUserIdActive(userId);
            List<Koi> koiList = await koiTask;
            ViewData["KoiId"] = new SelectList(koiList, "Id", "Name");
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
            bool updateSuccess = await registrationService.UpdateRegistration(Registration);


            if (!updateSuccess)
            {
                // Kiểm tra nếu CandidateProfile không tồn tại
                if (!await RegistrationExists(Registration.Id))
                {
                    return NotFound();
                }
                else
                {
                    // Throw exception hoặc ghi log nếu cần thiết
                    throw new DbUpdateConcurrencyException();
                }
            }

            //if (!wasCheckIn && Registration.IsCheckIn)
            //{
            //    // Check if another round has already started (same CompetitionId, different RoundId)
            //    bool roundExists = competitionRoundService.CheckIfAnotherRoundHasStarted(Registration.CompetitionCategory.CompetitionId);

            //    if (roundExists)
            //    {
            //        ModelState.AddModelError(string.Empty, "Another round has already started. You cannot check in.");
            //        return NotFound();
            //    }

            //    // Handle the creation of a new CompetitionRound
            //    if (Registration.CompetitionCategory == null || Registration.CompetitionCategory.CompetitionId == null)
            //    {
            //        ModelState.AddModelError(string.Empty, "Competition Category or Competition ID is missing.");
            //        return NotFound();
            //    }

            //    if (string.IsNullOrEmpty(Registration.KoiId))
            //    {
            //        ModelState.AddModelError(string.Empty, "Koi ID is missing.");
            //        return NotFound();
            //    }
            //    bool createCompetitionRoundSuccess = competitionRoundService.AddCompetitionRound(new CompetitionRound
            //    {
            //        CompetitionCategoryId = Registration.CompetitionCategory.CompetitionId,
            //        RoundId = "f60cef79ba9d481c8f96e89bcdebc74a", 
            //        KoiId = Registration.KoiId,
            //    });

            //    if (!createCompetitionRoundSuccess)
            //    {         
            //        ModelState.AddModelError(string.Empty, "Failed to create a new competition round.");
            //        return NotFound();
            //    }
            //}

            return RedirectToPage("./Index");
        }

        private async Task<bool> RegistrationExists(string id)
        {
            return await registrationService.GetRegistrationById(id) != null;
        }
    }
}
