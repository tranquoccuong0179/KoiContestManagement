using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface ICompetitionCategoryService
    {
        List<CompetitionCategory> GetCompetitionCategories();
        CompetitionCategory? GetCompetitionCategory(string id);
        bool AddCompetitionCategory(CompetitionCategory competitionCategory);
        bool UpdateCompetitionCategory(CompetitionCategory competitionCategory);
        bool DeleteCompetitionCategory(CompetitionCategory competitionCategory);
    }
}
