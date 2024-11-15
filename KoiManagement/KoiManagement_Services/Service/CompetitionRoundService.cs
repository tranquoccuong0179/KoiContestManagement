using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_DAO.DTO;
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

        public string GetCompetitionRoundId(string koiId, string roundId, string competitionCategoryId) => _competitionRoundRepository.GetCompetitionRoundId(koiId, roundId, competitionCategoryId);

        public List<CompetitionRoundInfoDTO> GetListIDByCompetitionCategoryIdNRoundId(string competitionCategoryId, string roundId) => _competitionRoundRepository.GetListIDByCompetitionCategoryIdNRoundId(competitionCategoryId, roundId);

        public bool AddCompetitionRound(CompetitionRound competitionRound) => _competitionRoundRepository.AddCompetitionRound(competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound) => _competitionRoundRepository.UpdateCompetitionRound(competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound) => _competitionRoundRepository.DeleteCompetitionRound(competitionRound);

        public Dictionary<(CompetitionCategory CompetitionCategory, Round Round), List<Koi>> GetCompetitionRoundWithKoi(string competitionId, string roundId) => _competitionRoundRepository.GetCompetitionRoundWithKoi(competitionId, roundId);

        public bool CheckIfAnotherRoundHasStarted(string competitionId, string id) => _competitionRoundRepository.CheckIfAnotherRoundHasStarted(competitionId, id);

        //public Task<List<CompetitionRound>> GetTopCompetitionRoundsByAverageScore(string competitionId, string roundId, int top) => _competitionRoundRepository.GetTopCompetitionRoundsByAverageScore(competitionId, roundId, top);
        public Task AddNewCompetitionRoundBasedOnTopScores(string competitionId, string roundId, int top) => _competitionRoundRepository.AddNewCompetitionRoundBasedOnTopScores(competitionId, roundId, top);

        //public Task AddNewCompetitionRoundBasedOnTopScores(string competitionId, string roundId, int top) 
        //{ 
            
        //    _competitionRoundRepository.AddNewCompetitionRoundBasedOnTopScores(competitionId,roundId,top);
        //}
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
