using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Repositories.Repository;
using KoiManagement_Services.IService;

namespace KoiManagement_Services.Service
{
    public class CompetitionRoundService : ICompetitionRoundService
    {
        private ICompetitionRoundRepository _competitionRoundRepository;
        public CompetitionRoundService()
        {
            _competitionRoundRepository = new CompetitionRoundRepository();
        }
        public List<CompetitionRound> GetAll() => _competitionRoundRepository.GetAll();

        public CompetitionRound? GetById(string id) => _competitionRoundRepository.GetById(id);

        public bool AddCompetitionRound(CompetitionRound competitionRound) => _competitionRoundRepository.AddCompetitionRound(competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound) => _competitionRoundRepository.UpdateCompetitionRound(competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound) => _competitionRoundRepository.DeleteCompetitionRound(competitionRound);

        public Dictionary<(CompetitionCategory CompetitionCategory, Round Round), List<Koi>> GetCompetitionRoundWithKoi(string competitionId, string roundId) => _competitionRoundRepository.GetCompetitionRoundWithKoi(competitionId, roundId);

        public bool CheckIfAnotherRoundHasStarted(string competitionId) => _competitionRoundRepository.CheckIfAnotherRoundHasStarted(competitionId);

        public Task<List<CompetitionRound>> GetTopCompetitionRoundsByAverageScore(string competitionId, string roundId, int top) => _competitionRoundRepository.GetTopCompetitionRoundsByAverageScore(competitionId,roundId,top);
        public Task AddNewCompetitionRoundBasedOnTopScores(string competitionId, string roundId, int top) => _competitionRoundRepository.AddNewCompetitionRoundBasedOnTopScores(competitionId,roundId,top);

        public bool DeleteCompetitionRoundByCompetitionIDAndRoundID(string competitionId, string roundId)
        {
            bool isDeleted = false;
            var allRounds = GetAll();
            var roundsToDelete = allRounds

                .Where(cr => cr.CompetitionCategoryId == competitionId && cr.RoundId == roundId)
                .ToList();

            foreach (var round in roundsToDelete)
            {
                isDeleted = DeleteCompetitionRound(round);
                if (!isDeleted)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
