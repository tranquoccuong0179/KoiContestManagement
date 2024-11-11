using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CriteriaPage
{
    public class IndexModel : PageModel
    {
        private readonly ICriteriaService criteriaService;

        public IndexModel(ICriteriaService criteriaService)
        {
            this.criteriaService = criteriaService;
        }

        public IList<Criteria> Criteria { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Criteria = criteriaService.GetCriterias();
        }
    }
}
