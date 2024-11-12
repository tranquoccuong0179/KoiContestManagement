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
    public class IndexModel : PageModel
    {
        private readonly IResultService resultService;

        public IndexModel(IResultService resultService)
        {
            this.resultService = resultService;
        }

        public IList<Result> Result { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Result = resultService.GetResults();
        }
    }
}
