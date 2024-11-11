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

namespace KoiManagement_GUI.Pages.RegistrationPages
{
    public class IndexModel : PageModel
    {
        private readonly IRegistrationService registrationService;

        public IndexModel(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        public IList<Registration> Registration { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Registration = registrationService.GetRegistrations();
        }
    }
}
