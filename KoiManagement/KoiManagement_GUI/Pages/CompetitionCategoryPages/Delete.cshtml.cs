using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
{
    public class DeleteModel : PageModel
    {
        private readonly ICompetitionCategoryService _ccService;

        public DeleteModel(ICompetitionCategoryService ccService)
        {
            _ccService = ccService;
        }

        [BindProperty]
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

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitioncategory = _ccService.GetCompetitionCategory(id);
            if (competitioncategory != null)
            {
                CompetitionCategory = competitioncategory;
                _ccService.DeleteCompetitionCategory(CompetitionCategory);
            }
            return RedirectToPage("./Index");
        }
    }
}
