using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CategoryPages
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bool result = _categoryService.AddCategory(Category);
            if (result)
            {
                return RedirectToPage("./Index");
            }
            ViewData["Result"] = "Category Name is already existed!";
            return Page();
        }
    }
}
