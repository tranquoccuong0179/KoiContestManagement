using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public bool AddCategory(Category category) => CategoryDAO.Instance.AddCategory(category);
        public bool DeleteCategory(Category category) => CategoryDAO.Instance.DeleteCategory(category);
        public Category? GetCategory(string id) => CategoryDAO.Instance.GetCategory(id);
        public List<Category> GetCategories() => CategoryDAO.Instance.GetCategories();
        public bool UpdateCategory(Category category) => CategoryDAO.Instance.UpdateCategory(category);
    }
}
