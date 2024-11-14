using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.MarkPages
{
    public class DeleteModel : PageModel
    {
        private readonly IMarkService markService;

        public DeleteModel(IMarkService markService)
        {
            this.markService = markService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = markService.GetMarkById(id);
            if (mark != null)
            {
                Mark = mark;
                markService.DeleteMark(Mark);
            }

            return RedirectToPage("./Index");
        }
    }
}
