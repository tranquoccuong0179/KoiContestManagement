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

namespace KoiManagement_GUI.Pages.CriteriaPointPage
{
    public class EditModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;
        private readonly ICriteriaService _criteriaService;
        private readonly IRefereeMarkService _refereeMarkService;

        public EditModel(KoiManagement_DAO.KoiManagementContext context, ICriteriaService criteriaService, IRefereeMarkService refereeMarkService)
        {
            _context = context;
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

            var criteriapoint =  await _context.CriteriaPoints.FirstOrDefaultAsync(m => m.RefereeMarkId == id);
            if (criteriapoint == null)
            {
                return NotFound();
            }
            CriteriaPoint = criteriapoint;
           ViewData["CriteriaId"] = new SelectList(_criteriaService.GetCriterias(), "Id", "Id");
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

            _context.Attach(CriteriaPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriteriaPointExists(CriteriaPoint.RefereeMarkId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
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
