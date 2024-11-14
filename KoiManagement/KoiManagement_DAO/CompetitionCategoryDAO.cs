using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_DAO
{
    public class CompetitionCategoryDAO
    {
        private KoiManagementContext context;
        private static CompetitionCategoryDAO instance;
        public CompetitionCategoryDAO()
        {
            context = new KoiManagementContext();
        }
        public static CompetitionCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompetitionCategoryDAO();
                }
                return instance;
            }
        }
        public List<CompetitionCategory> GetCompetitionCategories()
        {
            return context.CompetitionCategories.Include(c => c.Category).Include(c => c.Competition).OrderByDescending(c => c.CreateAt).ToList();
        }

        public CompetitionCategory? GetCompetitionCategory(string id)
        {
            return context.CompetitionCategories.SingleOrDefault(m => m.Id.Equals(id));
        }

        public List<CompetitionCategoryViewModel> GetCompetitionCategoryByCompetitionId(string id)
        {
            var result = (from cc in context.CompetitionCategories
                          join c in context.Categories on cc.CategoryId equals c.Id
                          where cc.CompetitionId == id
                          select new CompetitionCategoryViewModel
                          {
                              Id = cc.Id,                 
                              CategoryName = c.Name        
                          }).ToList();

            return result;
        }

        public bool AddCompetitionCategory(CompetitionCategory competitionCategory)
        {
            bool result = false;
            CompetitionCategory? existedcompetitionCategory = GetCompetitionCategory(competitionCategory.Id);
            try
            {
                if (existedcompetitionCategory == null)
                {
                    context.CompetitionCategories.Add(competitionCategory);
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
        public bool UpdateCompetitionCategory(CompetitionCategory competitionCategory)
        {
            bool result = false;
            CompetitionCategory? existedcompetitionCategory = GetCompetitionCategory(competitionCategory.Id);
            try
            {
                if (existedcompetitionCategory != null)
                {
                    context.Entry<CompetitionCategory>(competitionCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
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

        public bool DeleteCompetitionCategory(CompetitionCategory competitionCategory)
        {
            bool result = false;
            CompetitionCategory? existedCompetitionCategory = GetCompetitionCategory(competitionCategory.Id);
            try
            {
                if (existedCompetitionCategory != null)
                {
                    context.CompetitionCategories.Remove(existedCompetitionCategory);
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
        public void DeleteAllCategoriesForCompetition(string competitionId)
        {
            var competitionCategories = context.CompetitionCategories
                                                .Where(cc => cc.CompetitionId == competitionId)
                                                .ToList();
            context.CompetitionCategories.RemoveRange(competitionCategories);
            context.SaveChanges();
        }
        public void UpdateCompetitionCategories(string competitionId, List<string> selectedCategoryIds)
        {
            var existingCategories = context.CompetitionCategories
                                              .Where(cc => cc.CompetitionId == competitionId)
                                              .ToList();

            var categoriesToAdd = selectedCategoryIds.Except(existingCategories.Select(cc => cc.CategoryId)).ToList();
            var categoriesToRemove = existingCategories.Where(cc => !selectedCategoryIds.Contains(cc.CategoryId)).ToList();

            // Add new categories
            foreach (var categoryId in categoriesToAdd)
            {
                context.CompetitionCategories.Add(new CompetitionCategory { CompetitionId = competitionId, CategoryId = categoryId, Active = true });
            }

            // Remove unselected categories
            context.CompetitionCategories.RemoveRange(categoriesToRemove);
            context.SaveChanges();
        }

    }
}
