using KoiManagement_BusinessObjects;
using KoiManagement_DAO.DTO;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class ViewPointsModel : PageModel
    {
        private readonly ICompetitionRoundService _competitionRoundService;
        private readonly IRefereeMarkService _refereeMarkService;
        private readonly IRoundService _roundService;
        private readonly IMarkService _markService;

        public ViewPointsModel(ICompetitionRoundService competitionRoundService, IRefereeMarkService refereeMarkService, IRoundService roundService, IMarkService markService)
        {
            _competitionRoundService = competitionRoundService;
            _refereeMarkService = refereeMarkService;
            _roundService = roundService;
            _markService = markService;
        }

        public List<CompetitionRoundScore> TopKois { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string CompetitionCategoryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoundId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int KoiCount { get; set; }

        public bool IsLastRound { get; set; }
        public bool IsNextRoundStarted { get; set; }
        public bool CanAddNewRound { get; set; }
        public bool CanExportResult { get; set; }

        public async Task<IActionResult> OnGetAsync(string competitionCategoryId, string roundId, int koiCount)
        {
            CompetitionCategoryId = competitionCategoryId;
            RoundId = roundId;
            KoiCount = koiCount;

            if (string.IsNullOrEmpty(CompetitionCategoryId) || string.IsNullOrEmpty(RoundId))
            {
                return NotFound();
            }

            TopKois = _refereeMarkService.GetTopCompetitionRoundScoreByCRIdnRId(CompetitionCategoryId, RoundId, KoiCount);

            if (KoiCount < 5)
            {
                CanAddNewRound = false;
                CanExportResult = false;
                return Page();
            }

            var currentRound = _roundService.GetRound(RoundId);
            IsLastRound = _roundService.IsFinalRound(currentRound);

            if (!IsLastRound)
            {
                Round nextRound = _roundService.GetNextRound(KoiCount);
                IsNextRoundStarted = _competitionRoundService.CheckIfAnotherRoundHasStarted(CompetitionCategoryId, nextRound.Id);
                CanAddNewRound = !IsNextRoundStarted && TopKois != null && TopKois.Any();
            }

            CanExportResult = IsLastRound && TopKois != null && TopKois.Any();

            return Page();
        }
        public IActionResult OnPostAddRound()
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(CompetitionCategoryId) || string.IsNullOrEmpty(RoundId) || KoiCount <= 0)
            {
                TempData["ErrorMessage"] = "Invalid input data";
                return RedirectToPage("./Error");
            }

            int top = KoiCount;
            if (KoiCount < 5)
            {
                top = 5;
            }

            Round round = _roundService.GetNextRound(top);
            if (round == null)
            {
                TempData["ErrorMessage"] = "Failed to retrieve the next round for the competition.";
                return RedirectToPage("./Error");
            }

            var koisForMark = _refereeMarkService.GetTopCompetitionRoundScoreByCRIdnRId(CompetitionCategoryId, RoundId, KoiCount);
            foreach (var koi in koisForMark)
            {
                string competitionRoundId = _competitionRoundService.GetCompetitionRoundId(koi.KoiId, RoundId, CompetitionCategoryId);
                var mark = new Mark
                {
                    CompetitionRoundId = competitionRoundId,
                    Point = koi.AveragePoint
                };

                bool isMarkAdded = _markService.AddMark(mark);
                if (!isMarkAdded)
                {
                    TempData["ErrorMessage"] = "Failed to add Mark";
                    return RedirectToPage("./Error");
                }
            }


            var topKois = _refereeMarkService.GetTopCompetitionRoundScoreByCRIdnRId(CompetitionCategoryId, RoundId, round.OrderNumber);

            foreach (var koi in topKois)
            {

                var newRound = new CompetitionRound
                {
                    KoiId = koi.KoiId,
                    CompetitionCategoryId = CompetitionCategoryId,
                    RoundId = round.Id
                };

                bool isAdded = _competitionRoundService.AddCompetitionRound(newRound);
                if (!isAdded)
                {
                    TempData["ErrorMessage"] = "Failed to add one or more Kois to the new competition round.";
                    return RedirectToPage("./Error");
                }
            }

            TempData["SuccessMessage"] = "Top Kois have been successfully added to a new competition round.";
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostExportResult()
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(CompetitionCategoryId) || string.IsNullOrEmpty(RoundId) || KoiCount <= 0)
            {
                TempData["ErrorMessage"] = "Invalid input data";
                return RedirectToPage("./Error");
            }

            var koisForMark = _refereeMarkService.GetTopCompetitionRoundScoreByCRIdnRId(CompetitionCategoryId, RoundId, KoiCount);
            foreach (var koi in koisForMark)
            {
                string competitionRoundId = _competitionRoundService.GetCompetitionRoundId(koi.KoiId, RoundId, CompetitionCategoryId);
                var mark = new Mark
                {
                    CompetitionRoundId = competitionRoundId,
                    Point = koi.AveragePoint
                };

                bool isMarkAdded = _markService.AddMark(mark);
                if (!isMarkAdded)
                {
                    TempData["ErrorMessage"] = "Failed to add Mark";
                    return RedirectToPage("./Error");
                }
            }

            TempData["SuccessMessage"] = "Results have been successfully exported.";
            return RedirectToPage("./Index");
        }
    }
}