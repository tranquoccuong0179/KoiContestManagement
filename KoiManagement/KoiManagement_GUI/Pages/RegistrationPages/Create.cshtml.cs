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
using KoiManagement_Repositories.IRepository;
using System.Security.Claims;

namespace KoiManagement_GUI.Pages.RegistrationPages
{
    public class CreateModel : PageModel
    {
        private readonly IRegistrationService registrationService;
        private readonly IKoiService koiService;
        private readonly ICompetitionCategoryService competitionCategoryService;

        public CreateModel(IRegistrationService registrationService, IKoiService koiService, ICompetitionCategoryService competitionCategoryService)
        {
            this.registrationService = registrationService;
            this.koiService = koiService;
            this.competitionCategoryService = competitionCategoryService;
        }

        public async Task<IActionResult> OnGet(string? competitionId)
        {
            string userId = HttpContext.Session.GetString("Id");

            var competitionCategories = competitionCategoryService.GetCompetitionCategoryByCompetitionId(competitionId);
            ViewData["CompetitionCategoryId"] = new SelectList(competitionCategories, "Id", "CategoryName");
            Task<List<Koi>> koiTask = koiService.GetByUserIdActive(userId);
            List<Koi> koiList = await koiTask;
            ViewData["KoiId"] = new SelectList(koiList, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Registration Registration { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           registrationService.AddRegistration(Registration);
            //trả về trang user get all đăng kí của mình 
           return RedirectToPage("../CompetitionPages/Index");
        }
    }
}
