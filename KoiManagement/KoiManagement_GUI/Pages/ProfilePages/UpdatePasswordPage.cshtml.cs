using KoiManagement_Service.IService;
using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.ProfilePages
{
    public class UpdatePasswordPageModel : PageModel
    {
        private readonly IServiceManager serviceManager;
        private string userId;

        [BindProperty]
        public UserForUpdatePasswordDto UserForUpdatePasswordDto { get; set; }
        public UpdatePasswordPageModel(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            userId = HttpContext.Session.GetString("Id");
            var result = await serviceManager.AuthenticationService.UpdateUserPassword(userId, UserForUpdatePasswordDto);
            if (!result.Succeeded)
            {
                ViewData["ErrorMessage"] = "Current password is incorrect";
                return Page();
            }
            TempData["SuccessMessage"] = "Password updated successfully";
            return RedirectToPage("/ProfilePages/Index");
        }
    }
}
