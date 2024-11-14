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

namespace KoiManagement_GUI.Pages.RefereeMarkPages
{
    public class IndexModel : PageModel
    {
        private readonly IRefereeMarkService refereeMarkService;
        private readonly IAuthenticationService authenticationService;
        private readonly IKoiService koiService;
        private readonly ICriteriaService criteriaService;
        private readonly ICriteriaPointService criteriaPointService;

        public IndexModel(IRefereeMarkService refereeMarkService,
            IAuthenticationService authenticationService,
            IKoiService koiService,
            ICriteriaService criteriaService,
            ICriteriaPointService criteriaPointService)
        {
            this.refereeMarkService = refereeMarkService;
            this.authenticationService = authenticationService;
            this.koiService = koiService;
            this.criteriaService = criteriaService;
            this.criteriaPointService = criteriaPointService;
        }

        public IList<RefereeMark> RefereeMark { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RefereeMark = refereeMarkService.GetRefereeMarks();
        }
    }
}
