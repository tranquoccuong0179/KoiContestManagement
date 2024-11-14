using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CriteriaPointPage
{
    public class DeleteModel : PageModel
    {
        private readonly ICriteriaPointService _criteriaPointService;

        public DeleteModel(ICriteriaPointService criteriaPointService)
        {
            _criteriaPointService = criteriaPointService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criteriapoint = _criteriaPointService.GetCriteriaPoint(id);
            if (criteriapoint != null)
            {
                CriteriaPoint = criteriapoint;
                _criteriaPointService.DeleteCriteriaPoint(CriteriaPoint);
            }

            return RedirectToPage("./Index");
        }
    }
}
