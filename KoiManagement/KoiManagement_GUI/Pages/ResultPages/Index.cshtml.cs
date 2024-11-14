using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.ResultPages
{
    public class IndexModel : PageModel
    {
        private readonly IResultService resultService;

        public IndexModel(IResultService resultService)
        {
            this.resultService = resultService;
        }

        public IList<Result> Result { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Result = resultService.GetResults();
        }
    }
}
