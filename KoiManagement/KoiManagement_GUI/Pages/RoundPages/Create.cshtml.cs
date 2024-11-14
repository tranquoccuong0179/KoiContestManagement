using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.RoundPages
{
    public class CreateModel : PageModel
    {
        private readonly IRoundService _roundService;

        public CreateModel(IRoundService roundService)
        {
            _roundService = roundService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Round Round { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = _roundService.AddRound(Round);
            if (result) {
                return RedirectToPage("./Index");
            }
            ViewData["Result"] = "Name or OrderNumber is already existed!";
            return Page();
        }
    }
}
