using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.RegistrationPages
{
    public class DetailsModel : PageModel
    {
        private readonly IRegistrationService registrationService;

        public DetailsModel(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        public Registration Registration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await registrationService.GetRegistrationById(id);
            if (registration == null)
            {
                return NotFound();
            }
            else
            {
                Registration = registration;
            }
            return Page();
        }
    }
}
