using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_Repositories.IRepository
{
    public interface ICompetitionCategoryRepository
    {
        List<CompetitionCategory> GetCompetitionCategories();
        CompetitionCategory? GetCompetitionCategory(string id);
        List<CompetitionCategoryViewModel> GetCompetitionCategoryByCompetitionId(string id);
        bool AddCompetitionCategory(CompetitionCategory competitionCategory);
        bool UpdateCompetitionCategory(CompetitionCategory competitionCategory);
        bool DeleteCompetitionCategory(CompetitionCategory competitionCategory);
        void DeleteAllCategoriesForCompetition(string competitionId);
        void UpdateCompetitionCategories(string competitionId, List<string> selectedCategoryIds);
    }
}
