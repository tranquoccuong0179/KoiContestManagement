using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.Repository;

namespace KoiManagement_Repositories.IRepository
{
    public interface ICompetitionRoundRepository
    {
        public List<CompetitionRound> GetAll();

        public CompetitionRound? GetById(string id);

        public bool AddCompetitionRound(CompetitionRound competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound);
        public Dictionary<(Competition Competition, Round Round), List<Koi>> GetCompetitionRoundWithKoi(string? competitionId, string? roundId);

        public bool CheckIfAnotherRoundHasStarted(string competitionId);

        public Task<List<CompetitionRound>> GetTopCompetitionRoundsByAverageScore(string competitionId, string roundId, int top);
        public Task AddNewCompetitionRoundBasedOnTopScores(string competitionId, string roundId, int top);
    }
}
