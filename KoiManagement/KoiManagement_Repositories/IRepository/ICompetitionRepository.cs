using KoiManagement_BusinessObjects;

namespace KoiManagement_Repositories.IRepository
{
    public interface ICompetitionRepository
    {
        List<Competition> GetCompetitions();
        Competition? GetCompetition(string id);
        bool AddCompetition(Competition competition);
        bool UpdateCompetition(Competition competition);
        bool DeleteCompetition(Competition competition);
        Dictionary<Competition, List<Category?>> GetCompetitionsWithCategories(string? competitionId);
    }
}
