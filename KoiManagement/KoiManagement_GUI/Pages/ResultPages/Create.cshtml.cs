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
using KoiManagement_Services.KoiServices;
using Microsoft.EntityFrameworkCore.Internal;

namespace KoiManagement_GUI.Pages.ResultPages
{
    public class CreateModel : PageModel
    {
        private readonly IResultService resultService;
        private readonly IKoiService koiService;
        private readonly IRegistrationService registrationService;

        public CreateModel(IResultService resultService, IKoiService koiService, IRegistrationService registrationService)
        {
            this.resultService = resultService;
            this.koiService = koiService;
            this.registrationService = registrationService;
        }

        public IActionResult OnGet()
        {
            //ViewData["KoiId"] = new SelectList(_context.Kois, "Id", "Id");
            ViewData["RegistrationId"] = new SelectList(registrationService.GetRegistrations(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Result Result { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            resultService.AddResult(Result);

            return RedirectToPage("./Index");
        }
    }
}
