using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.MarkPages
{
    public class IndexModel : PageModel
    {
        private readonly IMarkService markService;

        public IndexModel(IMarkService markService)
        {
            this.markService = markService;
        }

        public IList<Mark> Mark { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Mark = markService.GetMarks();
        }
    }
}
