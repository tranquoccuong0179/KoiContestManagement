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

namespace KoiManagement_GUI.Pages.RefereeMarkPage
{
    public class IndexModel : PageModel
    {
        private readonly IRefereeMarkService refereeMarkService;

        public IndexModel(IRefereeMarkService refereeMarkService)
        {
            this.refereeMarkService = refereeMarkService;
        }

        public IList<RefereeMark> RefereeMark { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RefereeMark = refereeMarkService.GetRefereeMarks();
        }
    }
}
