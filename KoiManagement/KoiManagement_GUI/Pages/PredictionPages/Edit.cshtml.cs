using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.PredictionPages
{
    public class EditModel : PageModel
    {
        private readonly IPredictionService _predictionService;
        public EditModel(IPredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        [BindProperty]
        public Prediction Prediction { get; set; } = default!;

        public async Task<IActionResult> OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prediction = _predictionService.GetById(id);
            if (prediction == null)
            {
                return NotFound();
            }

            Prediction = prediction;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _predictionService.UpdatePrediction(Prediction);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredictionExists(Prediction.Id))
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

        private bool PredictionExists(string id)
        {
            return _predictionService.GetById(id) != null;
        }
    }
}
