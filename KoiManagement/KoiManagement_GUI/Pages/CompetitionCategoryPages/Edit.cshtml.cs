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

namespace KoiManagement_GUI.Pages.CompetitionCategoryPages
{
    public class EditModel : PageModel
    {
        private readonly ICompetitionCategoryService _ccService;
        private readonly ICategoryService _categoryService;
        private readonly ICompetitionService _competitionService;

        public EditModel(ICompetitionCategoryService ccService, ICategoryService categoryService, ICompetitionService competitionService, CompetitionCategory competitionCategory)
        {
            _ccService = ccService;
            _categoryService = categoryService;
            _competitionService = competitionService;
            CompetitionCategory = competitionCategory;
        }

        [BindProperty]
        public CompetitionCategory CompetitionCategory { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitioncategory =  _ccService.GetCompetitionCategory(id);
            if (competitioncategory == null)
            {
                return NotFound();
            }
            CompetitionCategory = competitioncategory;
           ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "Id");
           ViewData["CompetitionId"] = new SelectList(_competitionService.GetCompetitions(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _ccService.UpdateCompetitionCategory(CompetitionCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionCategoryExists(CompetitionCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompetitionCategoryExists(string id)
        {
            return _ccService.GetCompetitionCategory(id) != null;
        }
    }
}
