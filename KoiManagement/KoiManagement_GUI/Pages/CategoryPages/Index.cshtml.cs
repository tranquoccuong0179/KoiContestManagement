using KoiManagement_BusinessObjects;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiManagement_GUI.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IList<Category> Category { get; set; } = default!;

        public void OnGet()
        {
            Category = _categoryService.GetCategories();
        }
        public IActionResult OnPostDelete(string id)
        {
            var category = _categoryService.GetCategory(id);
            if (category != null)
            {
                _categoryService.DeleteCategory(category);
            }
            return RedirectToPage(); // After deletion, redirect back to the same page
        }
    }
}
