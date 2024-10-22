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

namespace KoiManagement_GUI.Pages.MarkPages
{
    public class DetailsModel : PageModel
    {
        private readonly IMarkService markService;

        public DetailsModel(IMarkService markService)
        {
            this.markService = markService;
        }

        public Mark Mark { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = markService.GetMarkById(id);
            if (mark == null)
            {
                return NotFound();
            }
            else
            {
                Mark = mark;
            }
            return Page();
        }
    }
}
