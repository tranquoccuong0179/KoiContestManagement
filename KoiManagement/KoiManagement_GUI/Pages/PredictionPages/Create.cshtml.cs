using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;

namespace KoiManagement_GUI.Pages.PredictionPages
{
    public class CreateModel : PageModel
    {
private readonly IPredictionService _predictionService;
        public CreateModel(IPredictionService predictionService, Prediction prediction)
        {
            _predictionService = predictionService;
            Prediction = prediction;
        }


        //public IActionResult OnGet()
        //{
        //ViewData["CompetitionRoundId"] = new SelectList(_context.CompetitionRounds, "Id", "Id");
        //ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
        //    return Page();
        //}

        [BindProperty]
        public Prediction Prediction { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _predictionService.AddPrediction(Prediction);
            return RedirectToPage("./Index");
        }
    }
}
