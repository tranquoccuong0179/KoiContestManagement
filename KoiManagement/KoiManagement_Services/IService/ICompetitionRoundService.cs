using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_Services.IService
{
    public interface ICompetitionRoundService
    {
        public List<CompetitionRound> GetAll();
        public Dictionary<(CompetitionCategory Competition, Round Round), List<Koi>> GetCompetitionRoundWithKoi(string? competitionId, string? roundId);
        public CompetitionRound? GetById(string id);

        public bool AddCompetitionRound(CompetitionRound competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound);

        public bool CheckIfAnotherRoundHasStarted(string competitionId);
        public Task<List<CompetitionRound>> GetTopCompetitionRoundsByAverageScore(string competitionId, string roundId, int top);

        public Task AddNewCompetitionRoundBasedOnTopScores(string competitionId, string roundId, int top);
    }
}
