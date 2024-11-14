using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class IndexModel : PageModel
    {
        private readonly ICompetitionRoundService competitionRoundService;

        public IndexModel(ICompetitionRoundService competitionRoundService)
        {
            this.competitionRoundService = competitionRoundService;
        }

        public Dictionary<(Competition Competition, Round Round), List<Koi>> CompetitionRoundWithKoi { get; set; } = default!;

        public void OnGet(string? competitionId, string? roundId)
        {
            CompetitionRoundWithKoi = competitionRoundService.GetCompetitionRoundWithKoi(competitionId, roundId);
        }

        //public class DeleteModel
        //{
        //    public string CompetitionId { get; set; }
        //    public string RoundId { get; set; }
        //}

        //[IgnoreAntiforgeryToken]
        //public async Task<IActionResult> OnPostDeleteAsync([FromBody] DeleteModel model)
        //{
        //    if (string.IsNullOrEmpty(model.CompetitionId) || string.IsNullOrEmpty(model.RoundId))
        //    {
        //        return BadRequest("Invalid competition or round ID.");
        //    }

        //    var success = competitionRoundService.DeleteCompetitionRoundByCompetitionIDAndRoundID(
        //        model.CompetitionId,
        //        model.RoundId);

        //    if (success)
        //    {
        //        return new JsonResult(new { success = true });
        //    }

        //    return StatusCode(500, "Error deleting competition rounds.");
        //}
    }
}

