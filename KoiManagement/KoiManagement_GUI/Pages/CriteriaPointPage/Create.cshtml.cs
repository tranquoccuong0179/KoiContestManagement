using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiManagement_GUI.Pages.CriteriaPointPage
{
    public class CreateModel : PageModel
    {
        private readonly ICriteriaPointService _criteriaPointService;
        private readonly ICriteriaService _criteriaService;
        private readonly IRefereeMarkService _refereeMarkService;
        public CreateModel(ICriteriaPointService criteriaPointService, ICriteriaService criteriaService, IRefereeMarkService refereeMarkService)
        {
            _criteriaPointService = criteriaPointService;
            _criteriaService = criteriaService;
            _refereeMarkService = refereeMarkService;
        }

        public IActionResult OnGet()
        {
            ViewData["CriteriaId"] = new SelectList(_criteriaService.GetCriterias(), "Id", "Name");
            ViewData["RefereeMarkId"] = new SelectList(_refereeMarkService.GetRefereeMarks(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CriteriaPoint CriteriaPoint { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_criteriaPointService.AddCriteriaPoint(CriteriaPoint);

            return RedirectToPage("./Index");
        }
    }
}
