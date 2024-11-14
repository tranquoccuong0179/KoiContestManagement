using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
{
    public class CreateModel : PageModel
    {
        private readonly ICompetitionService _competitionService;
        private readonly ICategoryService _categoryService;
        private readonly ICompetitionCategoryService _ccService;

        public CreateModel(ICompetitionService competitionService, ICategoryService categoryService, ICompetitionCategoryService ccService)
        {
            _competitionService = competitionService;
            _categoryService = categoryService;
            _ccService = ccService;
        }

        [BindProperty]
        public string CompetitionId { get; set; }

        public string CompetitionName { get; set; }
        public List<Category> Categories { get; set; }
        [BindProperty]
        public List<string> SelectedCategoryIds { get; set; } = new List<string>(); // Store selected category IDs

        public void OnGet(string competitionId)
        {
            // Get competition by ID and assign the name to display
            var competition = _competitionService.GetCompetition(competitionId);
            CompetitionId = competitionId;
            CompetitionName = competition.Name;

            // Load categories for checkbox selection
            Categories = _categoryService.GetCategories().ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Create CompetitionCategory entries for each selected category
            foreach (var categoryId in SelectedCategoryIds)
            {
                var competitionCategory = new CompetitionCategory
                {
                    CompetitionId = CompetitionId,
                    CategoryId = categoryId,
                    Active = true // Or set based on your requirements
                };

                // Add to context (assuming _context is available)
                _ccService.AddCompetitionCategory(competitionCategory);
            }

            return RedirectToPage("/CompetitionCategoryPages/Index");
        }
    }

}
