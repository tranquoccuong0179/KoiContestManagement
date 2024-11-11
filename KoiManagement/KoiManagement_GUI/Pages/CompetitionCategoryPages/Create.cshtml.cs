using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
{
    public class CreateModel : PageModel
    {
        private readonly ICompetitionCategoryService _ccService;
        private readonly ICategoryService _categoryService;
        private readonly ICompetitionService _competitionService;

        public CreateModel(ICompetitionCategoryService ccService, ICategoryService categoryService, ICompetitionService competitionService)
        {
            _ccService = ccService;
            _categoryService = categoryService;
            _competitionService = competitionService;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "Name");
            ViewData["CompetitionId"] = new SelectList(_competitionService.GetCompetitions(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CompetitionCategory CompetitionCategory { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _ccService.AddCompetitionCategory(CompetitionCategory);
            return RedirectToPage("./Index");
        }
    }
}
