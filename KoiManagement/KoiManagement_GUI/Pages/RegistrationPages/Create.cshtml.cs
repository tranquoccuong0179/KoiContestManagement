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

namespace KoiManagement_GUI.Pages.RegistrationPages
{
    public class CreateModel : PageModel
    {
        private readonly IRegistrationService registrationService;
        private readonly IKoiService koiService;

        public CreateModel(IRegistrationService registrationService, IKoiService koiService)
        {
            this.registrationService = registrationService;
            this.koiService = koiService;
        }

        public async Task<IActionResult> OnGet()
        {
            //ViewData["CompetitionCategoryId"] = new SelectList(_context.CompetitionCategories, "Id", "Id");
            Task<List<Koi>> koiTask = koiService.GetAll();
            List<Koi> koiList = await koiTask;
            ViewData["KoiId"] = new SelectList(koiList, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Registration Registration { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           registrationService.AddRegistration(Registration);

            return RedirectToPage("./Index");
        }
    }
}
