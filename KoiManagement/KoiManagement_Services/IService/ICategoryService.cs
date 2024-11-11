using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category? GetCategory(string id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
    }
}
