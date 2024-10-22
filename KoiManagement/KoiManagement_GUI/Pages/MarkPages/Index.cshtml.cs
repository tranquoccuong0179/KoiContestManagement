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
    public class IndexModel : PageModel
    {
        private readonly IMarkService markService;

        public IndexModel(IMarkService markService)
        {
            this.markService = markService;
        }

        public IList<Mark> Mark { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Mark = markService.GetMarks();          
        }
    }
}
