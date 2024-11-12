using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
{
    public class DetailsModel : PageModel
    {
        private readonly ICompetitionCategoryService _ccService;

        public DetailsModel(ICompetitionCategoryService ccService)
        {
            _ccService = ccService;
        }

        public CompetitionCategory CompetitionCategory { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitioncategory = _ccService.GetCompetitionCategory(id);
            if (competitioncategory == null)
            {
                return NotFound();
            }
            else
            {
                CompetitionCategory = competitioncategory;
            }
            return Page();
        }
    }
}
