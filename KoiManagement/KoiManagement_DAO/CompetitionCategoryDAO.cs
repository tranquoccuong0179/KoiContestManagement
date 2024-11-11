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
            return context.CompetitionCategories.Include(c => c.Category).Include(c => c.Competition).ToList();
        }

        public CompetitionCategory? GetCompetitionCategory(string id)
        {
            return context.CompetitionCategories.SingleOrDefault(m => m.Id.Equals(id));
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
    }
}
