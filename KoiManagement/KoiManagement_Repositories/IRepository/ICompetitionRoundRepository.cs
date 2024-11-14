using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.Repository;

namespace KoiManagement_Repositories.IRepository
{
    public interface ICompetitionRoundRepository
    {
        public List<CompetitionRound> GetAll();

        public CompetitionRound? GetById(string id);
        public string GetCompetitionRoundId(string koiId, string roundId, string competitionCategoryId);
        public bool AddCompetitionRound(CompetitionRound competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound);
        public Dictionary<(CompetitionCategory CompetitionCategory, Round Round), List<Koi>> GetCompetitionRoundWithKoi(string competitionId, string roundId);

        public bool CheckIfAnotherRoundHasStarted(string competitionId, string id);

        public Task<List<CompetitionRound>> GetTopCompetitionRoundsByAverageScore(string competitionId, string roundId, int top);
        public Task AddNewCompetitionRoundBasedOnTopScores(string competitionId, string roundId, int top);
    }
}
