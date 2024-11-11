using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages
{
    public class LogoutPageModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Clear();
            Response.Redirect("LoginPage");
        }
    }
}
