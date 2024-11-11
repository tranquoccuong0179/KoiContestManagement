using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;

namespace KoiManagement_GUI.Pages.PredictionPages
{
    public class IndexModel : PageModel
    {
        private readonly IPredictionService predictionService;
        public IndexModel(IPredictionService predictionService, IList<Prediction> prediction)
        {
            this.predictionService = predictionService;
            Prediction = prediction;
        }


        public IList<Prediction> Prediction { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Prediction = predictionService.GetAll();
        }
    }
}
