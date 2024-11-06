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

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly ICompetitionCategoryService _ccService;

        public IndexModel(ICompetitionCategoryService ccService)
        {
            _ccService = ccService;
        }

        public IList<CompetitionCategory> CompetitionCategory { get;set; } = default!;

        public void OnGetAsync()
        {
            CompetitionCategory = _ccService.GetCompetitionCategories();
        }
    }
}
