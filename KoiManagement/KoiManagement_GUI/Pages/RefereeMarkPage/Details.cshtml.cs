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
    public class DetailsModel : PageModel
    {
        private readonly IRefereeMarkService refereeMarkService;

        public DetailsModel(IRefereeMarkService refereeMarkService)
        {
            this.refereeMarkService = refereeMarkService;
        }

        public RefereeMark RefereeMark { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereemark = refereeMarkService.GetRefereeMark(id);
            if (refereemark == null)
            {
                return NotFound();
            }
            else
            {
                RefereeMark = refereemark;
            }
            return Page();
        }
    }
}
