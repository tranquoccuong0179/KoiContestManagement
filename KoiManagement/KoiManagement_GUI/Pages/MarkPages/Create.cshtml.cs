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

namespace KoiManagement_GUI.Pages.MarkPages
{
    public class CreateModel : PageModel
    {
        private readonly IMarkService markService;

        public CreateModel(IMarkService markService)
        {
            this.markService = markService;
        }

        //public IActionResult OnGet()
        //{
        //ViewData["CompetitionRoundId"] = new SelectList(_context.CompetitionRounds, "Id", "Id");
        //    return Page();
        //}

        [BindProperty]
        public Mark Mark { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            markService.AddMark(Mark);

            return RedirectToPage("./Index");
        }
    }
}
