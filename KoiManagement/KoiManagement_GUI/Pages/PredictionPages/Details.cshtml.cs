using KoiManagement_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.PredictionPages
{
    public class DetailsModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public DetailsModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

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
    }
}
