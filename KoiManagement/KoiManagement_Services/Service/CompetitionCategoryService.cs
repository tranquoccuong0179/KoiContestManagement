using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Repositories.Repository;
using KoiManagement_Services.IService;

namespace KoiManagement_Services.Service
{
    public class CompetitionCategoryService : ICompetitionCategoryService
    {
        private readonly ICompetitionCategoryRepository _competitionCategoryRepository;

        public CompetitionCategoryService()
        {
            _competitionCategoryRepository = new CompetitionCategoryRepository();
        }

        public List<CompetitionCategory> GetCompetitionCategories() => _competitionCategoryRepository.GetCompetitionCategories();

        public CompetitionCategory? GetCompetitionCategory(string id) => _competitionCategoryRepository.GetCompetitionCategory(id);
        public List<CompetitionCategoryViewModel> GetCompetitionCategoryByCompetitionId(string id) => _competitionCategoryRepository.GetCompetitionCategoryByCompetitionId(id);
        public bool AddCompetitionCategory(CompetitionCategory competitionCategory) => _competitionCategoryRepository.AddCompetitionCategory(competitionCategory);
        public bool UpdateCompetitionCategory(CompetitionCategory competitionCategory) => _competitionCategoryRepository.UpdateCompetitionCategory(competitionCategory);
        public bool DeleteCompetitionCategory(CompetitionCategory competitionCategory) => _competitionCategoryRepository.DeleteCompetitionCategory(competitionCategory);
        public void DeleteAllCategoriesForCompetition(string competitionId) => _competitionCategoryRepository.DeleteAllCategoriesForCompetition(competitionId);
        public void UpdateCompetitionCategories(string competitionId, List<string> selectedCategoryIds) => _competitionCategoryRepository.UpdateCompetitionCategories(competitionId, selectedCategoryIds);
    }
}
