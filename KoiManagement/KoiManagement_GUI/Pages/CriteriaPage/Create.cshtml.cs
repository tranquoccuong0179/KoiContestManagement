using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CriteriaPage
{
    public class CreateModel : PageModel
    {
        private readonly ICriteriaService criteriaService;

        public CreateModel(ICriteriaService criteriaService)
        {
            this.criteriaService = criteriaService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Criteria Criteria { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            criteriaService.AddCriteria(Criteria);

            return RedirectToPage("./Index");
        }
    }
}
