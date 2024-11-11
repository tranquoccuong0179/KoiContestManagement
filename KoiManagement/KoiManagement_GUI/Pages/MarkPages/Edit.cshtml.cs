using KoiManagement_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;

namespace KoiManagement_GUI.Pages.MarkPages
{
    public class EditModel : PageModel
    {
        private readonly IMarkService markService;
        private readonly ICompetitionRoundService competitionRoundService;
        public EditModel(IMarkService markService, ICompetitionRoundService competitionRoundService)
        {
            this.markService = markService;
            this.competitionRoundService = competitionRoundService;
        }

        [BindProperty]
        public Mark Mark { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark =  markService.GetMarkById(id);
            if (mark == null)
            {
                return NotFound();
            }
            Mark = mark;
           ViewData["CompetitionRoundId"] = new SelectList(competitionRoundService.GetAll(), "Id", "Id");
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

            bool updateSuccess = markService.UpdateMark(Mark);

            if (!updateSuccess)
            {
                // Kiểm tra nếu CandidateProfile không tồn tại
                if (!MarkExists(Mark.Id))
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

        private bool MarkExists(string id)
        {
            return markService.GetMarkById(id) != null;
        }
    }
}
