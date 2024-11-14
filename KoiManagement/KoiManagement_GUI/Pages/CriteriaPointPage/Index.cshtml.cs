using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CriteriaPointPage
{
    public class IndexModel : PageModel
    {
        private readonly ICriteriaPointService _criteriaPointService;

        public IndexModel(ICriteriaPointService criteriaPointService)
        {
            _criteriaPointService = criteriaPointService;
        }

        public IList<CriteriaPoint> CriteriaPoint { get; set; } = default!;

        public async Task OnGetAsync()
        {
            CriteriaPoint = _criteriaPointService.GetCriteriaPoints();
        }
    }
}
