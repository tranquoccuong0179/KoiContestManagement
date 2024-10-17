﻿using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category? GetCategory(string id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
    }
}
