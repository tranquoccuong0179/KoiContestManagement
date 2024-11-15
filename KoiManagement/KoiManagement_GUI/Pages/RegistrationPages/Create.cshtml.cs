using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiManagement_GUI.Pages.RegistrationPages
{
    public class CreateModel : PageModel
    {
        private readonly IRegistrationService registrationService;
        private readonly IKoiService koiService;
        private readonly ICompetitionCategoryService competitionCategoryService;
        private readonly ICategoryService categoryService;

        public CreateModel(IRegistrationService registrationService, IKoiService koiService, ICompetitionCategoryService competitionCategoryService, ICategoryService categoryService)
        {
            this.registrationService = registrationService;
            this.koiService = koiService;
            this.competitionCategoryService = competitionCategoryService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> OnGet(string? competitionId, string? categoryId)
        {
            string userId = HttpContext.Session.GetString("Id");

            var category = categoryService.GetCategory(categoryId);
            ViewData["CategoryName"] = category.Name;

            var competiotionCategory = competitionCategoryService.GetCompetitionCategory(competitionId, categoryId);
            ViewData["CompetitionCategoryId"] = competiotionCategory.Id;

            var registration = registrationService.GetRegistrations(userId);
            Task<List<Koi>> koiTask = koiService.GetByUserIdActive(userId);
            List<Koi> koiList = await koiTask;

            List<Koi> listCheck = new List<Koi>(koiList);
            foreach (var regis in registration)
            {
                foreach (var koi in koiList)
                {
                    if(regis.CompetitionCategoryId.Equals(competiotionCategory.Id) && regis.KoiId.Equals(koi.Id))
                    {
                        listCheck.Remove(koi);
                    }
                }
            }

            
            ViewData["KoiId"] = new SelectList(listCheck, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Registration Registration { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await registrationService.AddRegistration(Registration);
            //trả về trang user get all đăng kí của mình 
            return RedirectToPage("./Index");
        }
    }
}
