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

namespace KoiManagement_GUI.Pages.CriteriaPointPage
{
    public class DetailsModel : PageModel
    {
        private readonly ICriteriaPointService _criteriaPointService;

        public DetailsModel(ICriteriaPointService criteriaPointService)
        {
            _criteriaPointService = criteriaPointService;
        }

        public CriteriaPoint CriteriaPoint { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criteriapoint = _criteriaPointService.GetCriteriaPoint(id);
            if (criteriapoint == null)
            {
                return NotFound();
            }
            else
            {
                CriteriaPoint = criteriapoint;
            }
            return Page();
        }
    }
}
