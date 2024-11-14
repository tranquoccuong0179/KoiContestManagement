using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
    public class CompetitionRoundRepository : ICompetitionRoundRepository
    {
        public List<CompetitionRound> GetAll() => CompetitionRoundDAO.Instance.GetAll();

        public CompetitionRound? GetById(string id) => CompetitionRoundDAO.Instance.GetById(id);

        public  string GetCompetitionRoundId(string koiId, string roundId, string competitionCategoryId) => CompetitionRoundDAO.Instance.GetCompetitionRoundId(koiId, roundId, competitionCategoryId);
        public bool AddCompetitionRound(CompetitionRound competitionRound) => CompetitionRoundDAO.Instance.AddCompetitionRound(competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound) => CompetitionRoundDAO.Instance.UpdateCompetitionRound(competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound) => CompetitionRoundDAO.Instance.DeleteCompetitionRound(competitionRound);

        public Dictionary<(CompetitionCategory CompetitionCategory, Round Round), List<Koi>> GetCompetitionRoundWithKoi(string competitionId, string roundId) => CompetitionRoundDAO.Instance.GetCompetitionRoundWithKoi(competitionId, roundId);
        public bool CheckIfAnotherRoundHasStarted(string competitionId, string id) => CompetitionRoundDAO.Instance.CheckIfAnotherRoundHasStarted(competitionId, id);

        public Task<List<CompetitionRound>> GetTopCompetitionRoundsByAverageScore(string competitionId, string roundId, int top) => CompetitionRoundDAO.Instance.GetTopCompetitionRoundsByAverageScore(competitionId, roundId, top);

        public Task AddNewCompetitionRoundBasedOnTopScores(string competitionId, string roundId, int top) => CompetitionRoundDAO.Instance.AddNewCompetitionRoundBasedOnTopScoresAsync(competitionId,roundId,top);
    }
}
