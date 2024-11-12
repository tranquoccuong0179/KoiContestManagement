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

namespace KoiManagement_GUI.Pages.CompetitionRoundPages
{
    public class IndexModel : PageModel
    {
     private readonly ICompetitionRoundService competitionRoundService;
        public IndexModel(ICompetitionRoundService competitionRoundService)
        {
            this.competitionRoundService = competitionRoundService;
        }

        public IList<CompetitionRound> CompetitionRound { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CompetitionRound = competitionRoundService.GetAll();
        }
    }
}
