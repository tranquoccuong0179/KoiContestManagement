using KoiManagement_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.PredictionPages
{
    public class DeleteModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public DeleteModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prediction Prediction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prediction = await _context.Predictions.FirstOrDefaultAsync(m => m.Id == id);

            if (prediction == null)
            {
                return NotFound();
            }
            else
            {
                Prediction = prediction;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prediction = await _context.Predictions.FindAsync(id);
            if (prediction != null)
            {
                Prediction = prediction;
                _context.Predictions.Remove(Prediction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
