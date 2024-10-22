using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;

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
