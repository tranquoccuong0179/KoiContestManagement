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

namespace KoiManagement_GUI.Pages.CriteriaPage
{
    public class IndexModel : PageModel
    {
        private readonly ICriteriaService criteriaService;

        public IndexModel(ICriteriaService criteriaService)
        {
            this.criteriaService = criteriaService;
        }

        public IList<Criteria> Criteria { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Criteria = criteriaService.GetCriterias();
        }
    }
}
