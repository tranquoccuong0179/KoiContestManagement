using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
    public class CompetitionCategoryRepository : ICompetitionCategoryRepository
    {
        public List<CompetitionCategory> GetCompetitionCategories() => CompetitionCategoryDAO.Instance.GetCompetitionCategories();

        public CompetitionCategory? GetCompetitionCategory(string id) => CompetitionCategoryDAO.Instance.GetCompetitionCategory(id);
        public List<CompetitionCategoryViewModel> GetCompetitionCategoryByCompetitionId(string id) => CompetitionCategoryDAO.Instance.GetCompetitionCategoryByCompetitionId(id);
        public bool AddCompetitionCategory(CompetitionCategory competitionCategory) => CompetitionCategoryDAO.Instance.AddCompetitionCategory(competitionCategory);
        public bool UpdateCompetitionCategory(CompetitionCategory competitionCategory) => CompetitionCategoryDAO.Instance.UpdateCompetitionCategory(competitionCategory);
        public bool DeleteCompetitionCategory(CompetitionCategory competitionCategory) => CompetitionCategoryDAO.Instance.DeleteCompetitionCategory(competitionCategory);

        public void DeleteAllCategoriesForCompetition(string competitionId) => CompetitionCategoryDAO.Instance.DeleteAllCategoriesForCompetition(competitionId);

        public void UpdateCompetitionCategories(string competitionId, List<string> selectedCategoryIds) => CompetitionCategoryDAO.Instance.UpdateCompetitionCategories(competitionId, selectedCategoryIds);
    }
}
