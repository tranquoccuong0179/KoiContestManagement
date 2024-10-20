using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Repositories.Repository;
using KoiManagement_Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }
        public List<Category> GetCategories() => _categoryRepository.GetCategories();
        public Category? GetCategory(string id) => _categoryRepository.GetCategory(id);
        public bool AddCategory(Category category) => _categoryRepository.AddCategory(category);
        public bool UpdateCategory(Category category) => _categoryRepository.UpdateCategory(category);
        public bool DeleteCategory(Category category) => _categoryRepository.DeleteCategory(category);
    }
}
