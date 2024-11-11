using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly ICompetitionCategoryService _ccService;
        private readonly ICompetitionService _competitionService;

        public IndexModel(ICompetitionCategoryService ccService, ICompetitionService competitionService)
        {
            _ccService = ccService;
            _competitionService = competitionService;
        }

        public IList<CompetitionCategory> CompetitionCategory { get; set; } = default!;
        public Dictionary<Competition, List<Category?>> CompetitionsWithCategories { get; set; } = default!;

        public void OnGet(string? competitionId)
        {
            if (!string.IsNullOrEmpty(competitionId))
            {
                CompetitionsWithCategories = _competitionService.GetCompetitionsWithCategories(competitionId);
            }
            CompetitionsWithCategories = _competitionService.GetCompetitionsWithCategories(null);
        }
    }
}
