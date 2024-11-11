using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public string CompetitionName { get; set; } = default!;
        public string CompetitionId { get; set; } = default!;

        // List of categories for checkboxes
        public List<Category> Categories { get; set; } = default!;

        // Holds selected category IDs when submitting
        [BindProperty]
        public List<string> SelectedCategoryIds { get; set; } = new();
        public List<bool> IsActive { get; set; } = new();
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
                    CompetitionId = CompetitionId, // Bound from the hidden field
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
