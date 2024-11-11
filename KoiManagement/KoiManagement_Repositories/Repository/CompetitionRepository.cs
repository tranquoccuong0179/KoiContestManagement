using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
    public class CompetitionRepository : ICompetitionRepository
    {
        public bool AddCompetition(Competition competition) => CompetitionDAO.Instance.AddCompetition(competition);
        public bool DeleteCompetition(Competition competition) => CompetitionDAO.Instance.DeleteCompetition(competition);
        public Competition? GetCompetition(string id) => CompetitionDAO.Instance.GetCompetition(id);
        public List<Competition> GetCompetitions() => CompetitionDAO.Instance.GetCompetitions();

        public Dictionary<Competition, List<Category?>> GetCompetitionsWithCategories() => CompetitionDAO.Instance.GetCompetitionsWithCategories();

        public bool UpdateCompetition(Competition competition) => CompetitionDAO.Instance.UpdateCompetition(competition);
    }
}
