using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
    public class CompetitionRoundRepository : ICompetitionRoundRepository
    {
        public List<CompetitionRound> GetAll() => CompetitionRoundDAO.Instance.GetAll();

        public CompetitionRound? GetById(string id) => CompetitionRoundDAO.Instance.GetById(id);

        public bool AddCompetitionRound(CompetitionRound competitionRound) => CompetitionRoundDAO.Instance.AddCompetitionRound(competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound) => CompetitionRoundDAO.Instance.UpdateCompetitionRound(competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound) => CompetitionRoundDAO.Instance.DeleteCompetitionRound(competitionRound);

    }
}
