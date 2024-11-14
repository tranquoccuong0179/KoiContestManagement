using KoiManagement_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.RefereeMarkPages
{
    public class DeleteModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public DeleteModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RefereeMark RefereeMark { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereemark = await _context.RefereeMarks.FirstOrDefaultAsync(m => m.Id == id);

            if (refereemark == null)
            {
                return NotFound();
            }
            else
            {
                RefereeMark = refereemark;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereemark = await _context.RefereeMarks.FindAsync(id);
            if (refereemark != null)
            {
                RefereeMark = refereemark;
                _context.RefereeMarks.Remove(RefereeMark);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
