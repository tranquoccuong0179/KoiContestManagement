using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
{
    public class DetailsModel : PageModel
    {
        private readonly ICompetitionService _competitionService;
        private readonly ICategoryService _categoryService;
        private readonly ICompetitionCategoryService _ccService;

        public DetailsModel(ICompetitionService competitionService, ICategoryService categoryService, ICompetitionCategoryService ccService)
        {
            _competitionService = competitionService;
            _categoryService = categoryService;
            _ccService = ccService;
        }

        [BindProperty]
        public string CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        [BindProperty]
        public List<string> SelectedCategoryIds { get; set; } = new List<string>();

        public List<Category> Categories { get; set; } = new List<Category>();

        public void OnGet(string competitionId)
        {
            var competition = _competitionService.GetCompetition(competitionId);
            CompetitionId = competitionId;
            CompetitionName = competition.Name;

            // Get all categories
            Categories = _categoryService.GetCategories().ToList();

            // Load selected categories
            SelectedCategoryIds = _competitionService.GetCompetitionsWithCategories(competitionId).SelectMany(c => c.Value).Where(category => category != null).Select(category => category!.Id).ToList();
        }

        public IActionResult OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update competition categories
            _ccService.UpdateCompetitionCategories(CompetitionId, SelectedCategoryIds);

            return RedirectToPage("Index");
        }

        public IActionResult OnPostDeleteAsync()
        {
            _ccService.DeleteAllCategoriesForCompetition(CompetitionId);
            return RedirectToPage("Index");
        }
    }
}
