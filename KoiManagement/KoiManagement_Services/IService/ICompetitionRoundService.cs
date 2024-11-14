using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface ICompetitionRoundService
    {
        public List<CompetitionRound> GetAll();
        public Dictionary<(CompetitionCategory CompetitionCategory, Round Round), List<Koi>> GetCompetitionRoundWithKoi(string? competitionId, string? roundId);
        public CompetitionRound? GetById(string id);

        public bool AddCompetitionRound(CompetitionRound competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound);

        public bool CheckIfAnotherRoundHasStarted(string competitionId, string id);
        public Task<List<CompetitionRound>> GetTopCompetitionRoundsByAverageScore(string competitionId, string roundId, int top);

        public Task AddNewCompetitionRoundBasedOnTopScores(string competitionId, string roundId, int top);

        public bool DeleteCompetitionRoundByCompetitionIDAndRoundID(string competitionId, string roundId);
    }
}
