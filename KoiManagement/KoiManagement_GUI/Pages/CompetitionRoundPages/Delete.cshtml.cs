using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class DeleteModel : PageModel
    {
        private readonly ICompetitionRoundService _competitionRoundService;

        public DeleteModel(ICompetitionRoundService competitionRoundService)
        {
            _competitionRoundService = competitionRoundService;
        }

        [BindProperty]
        public string CompetitionCategoryId { get; set; }

        [BindProperty]
        public string RoundId { get; set; }

        public string CompetitionName { get; set; }
        public string CategoryName { get; set; }
        public string RoundName { get; set; }

        public IActionResult OnGet(string competitionCategoryId, string roundId)
        {
            if (string.IsNullOrEmpty(competitionCategoryId) || string.IsNullOrEmpty(roundId))
            {
                TempData["ErrorMessage"] = "Không tìm thấy thông tin vòng thi đấu";
                return RedirectToPage("./Index");
            }

            var competitionRounds = _competitionRoundService.GetCompetitionRoundWithKoi(competitionCategoryId, roundId);

            if (competitionRounds == null || !competitionRounds.Any())
            {
                TempData["ErrorMessage"] = "Không tìm thấy thông tin vòng thi đấu";
                return RedirectToPage("./Index");
            }

            var firstItem = competitionRounds.First();
            CompetitionCategoryId = competitionCategoryId;
            RoundId = roundId;
            CompetitionName = firstItem.Key.CompetitionCategory?.Competition?.Name;
            CategoryName = firstItem.Key.CompetitionCategory?.Category.Name;
            RoundName = firstItem.Key.Round?.Name;

            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                if (string.IsNullOrEmpty(CompetitionCategoryId) || string.IsNullOrEmpty(RoundId))
                {
                    TempData["ErrorMessage"] = "Thông tin không hợp lệ";
                    return RedirectToPage("./Index");
                }

                var success = _competitionRoundService.DeleteCompetitionRoundByCompetitionIDAndRoundID(
                    CompetitionCategoryId,
                    RoundId);

                if (success)
                {
                    TempData["SuccessMessage"] = "Xóa vòng thi đấu thành công";
                    return RedirectToPage("./Index");
                }

                ModelState.AddModelError("", "Có lỗi xảy ra khi xóa vòng thi đấu");
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Lỗi: {ex.Message}");
                return Page();
            }
        }
    }
}
