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
        public EditModel(IRegistrationService registrationService, IKoiService koiService, ICompetitionCategoryService competitionCategoryService)
        {
            this.registrationService = registrationService;
            this.koiService = koiService;
            this.competitionCategoryService = competitionCategoryService;
        }

        [BindProperty]
        public Registration Registration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration =  registrationService.GetRegistrationById(id);
            if (registration == null)
            {
                return NotFound();
            }
            Registration = registration;
            ViewData["CompetitionCategoryId"] = new SelectList(competitionCategoryService.GetCompetitionCategories(), "Id", "Id");
            Task<List<Koi>> koiTask = koiService.GetAll();
            List<Koi> koiList = await koiTask;
            ViewData["KoiId"] = new SelectList(koiList, "Id", "Id");
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

            bool updateSuccess = registrationService.UpdateRegistration(Registration);


            if (!updateSuccess)
            {
                // Kiểm tra nếu CandidateProfile không tồn tại
                if (!RegistrationExists(Registration.Id))
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

        private bool RegistrationExists(string id)
        {
            return registrationService.GetRegistrationById(id) != null;
        }
    }
}
