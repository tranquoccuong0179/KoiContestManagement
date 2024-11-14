using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.RoundPages
{
    public class IndexModel : PageModel
    {
        private readonly IRoundService _roundService;
        public IndexModel(IRoundService roundService)
        {
            _roundService = roundService;
        }

        public IList<Round> Round { get; set; } = default!;

        public void OnGet()
        {
            Round = _roundService.GetRounds();
        }
        public IActionResult OnPostDelete(string id)
        {
            var round = _roundService.GetRound(id);
            if (round != null)
            {
                _roundService.DeleteRound(round);
            }
            return RedirectToPage(); // After deletion, redirect back to the same page
        }
    }
}
