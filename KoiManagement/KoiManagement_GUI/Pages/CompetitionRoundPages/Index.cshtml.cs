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

        public Dictionary<(CompetitionCategory CompetitionCategory, Round Round), List<Koi>> CompetitionRoundWithKoi { get; set; } = default!;

        public void OnGet(string competitionCategoryId, string roundId)
        {
            CompetitionRoundWithKoi = competitionRoundService.GetCompetitionRoundWithKoi(competitionCategoryId, roundId);
                                      
        }
        
    }
}

