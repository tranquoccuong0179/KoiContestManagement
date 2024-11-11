using KoiManagement_BusinessObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_GUI.Pages.RoundPages
{
    public class IndexModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public IndexModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

        public IList<Round> Round { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Round = await _context.Rounds.ToListAsync();
        }
    }
}
