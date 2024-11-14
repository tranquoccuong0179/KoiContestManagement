using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;

namespace KoiManagement_GUI.Pages.RegistrationPages
{
    public class DeleteModel : PageModel
    {
        private readonly IRegistrationService registrationService;

        public DeleteModel(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await registrationService.GetRegistrationById(id);
            if (registration != null)
            {
                Registration = registration;
                await registrationService.DeleteRegistration(Registration);
            }

            return RedirectToPage("./Index");
        }
    }
}
