using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.RoundPages
{
    public class EditModel : PageModel
    {
        private readonly IRoundService _roundService;

        public EditModel(IRoundService roundService)
        {
            _roundService = roundService;
        }

        [BindProperty]
        public Round Round { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var round = _roundService.GetRound(id);
            if (round == null)
            {
                return NotFound();
            }
            Round = round;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                bool result = _roundService.UpdateRound(Round);
                if (result)
                {
                    return RedirectToPage("./Index"); ;
                }
                else
                {
                    ViewData["Result"] = "Name or OrderNumber is already existed!";
                    return Page();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundExists(Round.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RoundExists(string id)
        {
            return _roundService.GetRound(id) != null;
        }
    }
}
