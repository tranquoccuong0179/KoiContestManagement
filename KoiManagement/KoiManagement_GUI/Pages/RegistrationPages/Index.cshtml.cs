using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.RegistrationPages
{
    public class IndexModel : PageModel
    {
        private readonly IRegistrationService _registrationService;

        public IndexModel(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public IList<Registration> Registration { get; set; } = default!;

        public async Task OnGetAsync()
        {
            string userId = HttpContext.Session.GetString("Id");

            var userRole = HttpContext.Session.GetString("Role");
            if (userRole == "Admin")
            {
                Registration = _registrationService.GetRegistrationsAll();
            }
            else
            {
                Registration = _registrationService.GetRegistrations(userId);
            }
        }
    }
}
