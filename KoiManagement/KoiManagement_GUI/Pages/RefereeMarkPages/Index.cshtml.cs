using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_GUI.Pages.RefereeMarkPages
{
    public class IndexModel : PageModel
    {
        private readonly KoiManagement_DAO.KoiManagementContext _context;

        public IndexModel(KoiManagement_DAO.KoiManagementContext context)
        {
            _context = context;
        }

        public IList<RefereeMark> RefereeMark { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RefereeMark = await _context.RefereeMarks
                .Include(r => r.CompetitionRound)
                .Include(r => r.User).ToListAsync();
        }
    }
}
