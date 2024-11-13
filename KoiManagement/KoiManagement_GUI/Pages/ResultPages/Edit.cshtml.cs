using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;
using KoiManagement_Services.KoiServices;
using Microsoft.EntityFrameworkCore.Internal;
using KoiManagement_Services.Service;

namespace KoiManagement_GUI.Pages.ResultPages
{
    public class EditModel : PageModel
    {
        private readonly IResultService resultService;
        private readonly IKoiService koiService;
        private readonly IRegistrationService registrationService;

        public EditModel(IResultService resultService, IKoiService koiService, IRegistrationService registrationService)
        {
            this.resultService = resultService;
            this.koiService = koiService;
            this.registrationService = registrationService;
        }

        [BindProperty]
        public Result Result { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result =  resultService.GetResultById(id);
            if (result == null)
            {
                return NotFound();
            }
            Result = result;

            string userId = HttpContext.Session.GetString("Id");

            Task<List<Koi>> koiTask = koiService.GetAll();
            List<Koi> koiList = await koiTask;
            ViewData["KoiId"] = new SelectList(koiList, "Id", "Id");
            ViewData["RegistrationId"] = new SelectList(registrationService.GetRegistrations(userId), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool updateSuccess = resultService.UpdateResult(Result);


            if (!updateSuccess)
            {
                // Kiểm tra nếu CandidateProfile không tồn tại
                if (!ResultExists(Result.Id))
                {
                    return NotFound();
                }
                else
                {
                    // Throw exception hoặc ghi log nếu cần thiết
                    throw new DbUpdateConcurrencyException();
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ResultExists(string id)
        {
            return resultService.GetResultById(id) != null;
        }
    }
}
