using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages
{
	public class LogoutPageModel : PageModel
	{
		public void OnGet()
		{
		}

		public IActionResult OnPost()
		{
			HttpContext.Session.Clear();
			return RedirectToPage("LoginPage");
		}
	}
}
