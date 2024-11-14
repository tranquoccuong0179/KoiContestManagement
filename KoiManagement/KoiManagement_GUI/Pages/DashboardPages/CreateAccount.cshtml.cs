using KoiManagement_Service.IService;
using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.DashboardPages
{
    public class CreateAccountModel : PageModel
    {
        private readonly IServiceManager serviceManager;
        [BindProperty]
        public UserForRegistrationDto UserForRegistration { get; set; }
        public List<IdentityRole> Roles { get; set; }
        [BindProperty]
        public string ChosenRole { get; set; }

        public CreateAccountModel(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
        public async Task<IActionResult> OnGet()
        {
            Roles = await serviceManager.AuthenticationService.GetRoles();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Roles = await serviceManager.AuthenticationService.GetRoles();
                return Page();
            }
            var result = await serviceManager.AuthenticationService.CreateAccountByAdmin(UserForRegistration, ChosenRole);
            Roles = await serviceManager.AuthenticationService.GetRoles();
            if (result.Succeeded)
            {
                ViewData["CreateAccountSuccess"] = "Create account successfully";
                return Page();
            }
            ViewData["CreateAccountFail"] = "Username already existed";
            return Page();
        }
    }
}
