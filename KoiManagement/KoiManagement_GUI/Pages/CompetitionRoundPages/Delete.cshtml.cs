using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiManagement_Services.IService;

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
        public string CompetitionId { get; set; }

        [BindProperty]
        public string RoundId { get; set; }

        public string CompetitionName { get; set; }
        public string RoundName { get; set; }

        public IActionResult OnGet(string competitionId, string roundId)
        {
            if (string.IsNullOrEmpty(competitionId) || string.IsNullOrEmpty(roundId))
            {
                return NotFound();
            }

            var competitionRound = _competitionRoundService.GetCompetitionRoundWithKoi(competitionId, roundId);

            if (competitionRound == null || !competitionRound.Any())
            {
                return NotFound();
            }

            var firstItem = competitionRound.First();
            CompetitionId = competitionId;
            RoundId = roundId;
            CompetitionName = firstItem.Key.Competition.Name;
            RoundName = firstItem.Key.Round.Name;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(CompetitionId) || string.IsNullOrEmpty(RoundId))
            {
                return NotFound();
            }

            var success = _competitionRoundService.DeleteCompetitionRoundByCompetitionIDAndRoundID(
                CompetitionId,
                RoundId);

            if (success)
            {
                TempData["SuccessMessage"] = "Xóa vòng thi đấu thành công";
                return RedirectToPage("./Index");
            }

            ModelState.AddModelError("", "Có lỗi xảy ra khi xóa vòng thi đấu");
            return Page();
        }
    }
}
