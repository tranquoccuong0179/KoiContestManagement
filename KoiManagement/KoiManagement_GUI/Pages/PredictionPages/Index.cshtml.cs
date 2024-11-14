using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.PredictionPages
{
    public class IndexModel : PageModel
    {
        private readonly IPredictionService predictionService;
        public IndexModel(IPredictionService predictionService)
        {
            this.predictionService = predictionService;

        }

        public IList<Prediction> Prediction { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Prediction = predictionService.GetAll();
        }
    }
}
