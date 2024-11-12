using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.CriteriaPage
{
    public class EditModel : PageModel
    {
        private readonly ICriteriaService criteriaService;

        public EditModel(ICriteriaService criteriaService)
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
            Criteria = criteria;
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

            bool updateSuccess = criteriaService.UpdateCriteria(Criteria);

            if (!updateSuccess)
            {
                if (!CriteriaExists(Criteria.Id))
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

        private bool CriteriaExists(string id)
        {
            return criteriaService.GetCriteria(id) != null;
        }
    }
}
