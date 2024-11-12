using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;

namespace KoiManagement_GUI.Pages.CriteriaPointPage
{
    public class EditModel : PageModel
    {
        private readonly ICriteriaPointService _criteriaPointService;
        private readonly ICriteriaService _criteriaService;
        private readonly IRefereeMarkService _refereeMarkService;

        public EditModel(ICriteriaPointService criteriaPointService, ICriteriaService criteriaService, IRefereeMarkService refereeMarkService)
        {
            _criteriaPointService = criteriaPointService;
            _criteriaService = criteriaService;
            _refereeMarkService = refereeMarkService;
        }

        [BindProperty]
        public CriteriaPoint CriteriaPoint { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criteriapoint =  _criteriaPointService.GetCriteriaPoint(id);
            if (criteriapoint == null)
            {
                return NotFound();
            }
            CriteriaPoint = criteriapoint;
            ViewData["CriteriaId"] = new SelectList(_criteriaService.GetCriterias(), "Id", "Name");
            ViewData["RefereeMarkId"] = new SelectList(_refereeMarkService.GetRefereeMarks(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool updateSuccess = _criteriaPointService.UpdateCriteriaPoint(CriteriaPoint);

            if (!updateSuccess)
            {
                if (!CriteriaPointExists(CriteriaPoint.Id))
                {
                    return NotFound();
                }
                else
                {
                    // Throw exception hoặc ghi log nếu cần thiết
                    throw new DbUpdateConcurrencyException();
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CriteriaPointExists(string id)
        {
            return _criteriaService.GetCriteria(id) != null;
        }
    }
}
