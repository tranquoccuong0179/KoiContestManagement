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

namespace KoiManagement_GUI.Pages.RegistrationPages
{
    public class CreateModel : PageModel
    {
        private readonly IRegistrationService registrationService;

        public CreateModel(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        public IActionResult OnGet()
        {
        //ViewData["CompetitionCategoryId"] = new SelectList(_context.CompetitionCategories, "Id", "Id");
        //ViewData["KoiId"] = new SelectList(_context.Kois, "Id", "Id");
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
