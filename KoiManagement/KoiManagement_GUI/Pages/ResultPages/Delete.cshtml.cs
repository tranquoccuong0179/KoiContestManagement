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

namespace KoiManagement_GUI.Pages.ResultPages
{
    public class DeleteModel : PageModel
    {
        private readonly IResultService resultService;

        public DeleteModel(IResultService resultService)
        {
            this.resultService = resultService;
        }

        [BindProperty]
        public Result Result { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = resultService.GetResultById(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                Result = result;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = resultService.GetResultById(id);
            if (result != null)
            {
                Result = result;
                resultService.DeleteResult(Result);
            }

            return RedirectToPage("./Index");
        }
    }
}
