using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CriteriaPage
{
    public class DeleteModel : PageModel
    {
        private readonly ICriteriaService criteriaService;

        public DeleteModel(ICriteriaService criteriaService)
        {
            this.criteriaService = criteriaService;
        }

        [BindProperty]
        public Criteria Criteria { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criteria = criteriaService.GetCriteria(id);

            if (criteria == null)
            {
                return NotFound();
            }
            else
            {
                Criteria = criteria;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criteria = criteriaService.GetCriteria(id);
            if (criteria != null)
            {
                Criteria = criteria;
                criteriaService.DeleteCriteria(criteria);
            }

            return RedirectToPage("./Index");
        }
    }
}
