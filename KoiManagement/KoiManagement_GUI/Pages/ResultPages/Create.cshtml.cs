using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<IActionResult> OnGet()
        {
            string userId = HttpContext.Session.GetString("Id");

            Task<List<Koi>> koiTask = koiService.GetAll();
            List<Koi> koiList = await koiTask;
            ViewData["KoiId"] = new SelectList(koiList, "Id", "Id");
            ViewData["RegistrationId"] = new SelectList(registrationService.GetRegistrations(userId), "Id", "Id");
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
