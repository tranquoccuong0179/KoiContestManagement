using KoiManagement_BusinessObjects;
using System.Text;

namespace KoiManagement_DAO
{
    public class CategoryDAO
    {
        private KoiManagementContext context;
        private static CategoryDAO instance;
        public CategoryDAO()
        {
            context = new KoiManagementContext();
        }
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }
        public List<Category> GetCategories()
        {
            return context.Categories.OrderByDescending(c => c.CreateAt).ToList();
        }

        public Category? GetCategory(string id)
        {
            return context.Categories.SingleOrDefault(m => m.Id.Equals(id));
        }

        public bool AddCategory(Category category)
        {
            bool result = false;
            Category? existedCategory = GetCategory(category.Id);
            try
            {
                if (existedCategory == null)
                {
                    if (context.Categories.Any(r => r.Name.Equals(category.Name)))
                    {
                        return false;
                    }
                    context.Categories.Add(category);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public bool UpdateCategory(Category category)
        {
            bool result = false;
            Category? existedCategory = GetCategory(category.Id);
            try
            {
                if (existedCategory != null)
                {
                    bool nameExists = context.Categories.Any(r => r.Name == category.Name && r.Id != category.Id);
                    if (nameExists)
                    {
                        return false;
                    }
                    context.Entry(existedCategory).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }

        public bool DeleteCategory(Category category)
        {
            bool result = false;
            Category? existedCategory = GetCategory(category.Id);
            try
            {
                if (existedCategory != null)
                {
                    context.Categories.Remove(existedCategory);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
    }
}
