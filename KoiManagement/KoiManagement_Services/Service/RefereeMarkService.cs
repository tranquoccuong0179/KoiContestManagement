using KoiManagement_BusinessObjects;
using KoiManagement_DAO.DTO;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Services.IService;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.Service
{
    public class RefereeMarkService : IRefereeMarkService
    {
        private readonly IRefereeMarkRepository refereeMarkRepository;
        private readonly ICompetitionRoundRepository competitionRoundRepository;
        public RefereeMarkService(IRefereeMarkRepository refereeMarkRepository,ICompetitionRoundRepository competitionRoundRepository)
        {
            this.refereeMarkRepository = refereeMarkRepository;
            this.competitionRoundRepository = competitionRoundRepository;
        }

        public bool AddRefereeMark(RefereeMark refereeMarkNew) => refereeMarkRepository.AddRefereeMark(refereeMarkNew);

        public bool DeleteRefereeMark(RefereeMark refereeMarkDelete) => refereeMarkRepository.DeleteRefereeMark(refereeMarkDelete);

        public RefereeMark? GetExistRefereeMark(string competitionId, string userId) => refereeMarkRepository.GetExistRefereeMark(competitionId, userId);

        public RefereeMark GetRefereeMark(string id) => refereeMarkRepository.GetRefereeMark(id);

        public List<RefereeMark> GetRefereeMarks() => refereeMarkRepository.GetRefereeMarks();

        public bool UpdateRefereeMark(RefereeMark refereeMarkUpdate) => refereeMarkRepository.UpdateRefereeMark(refereeMarkUpdate);

        public List<CompetitionRoundScore> GetTopCompetitionRoundScoreByCRIdnRId(string competitionCategoryId, string roundId, int top)
        {
            List<CompetitionRoundInfoDTO> competitionRoundInfoList = competitionRoundRepository.GetListIDByCompetitionCategoryIdNRoundId(competitionCategoryId, roundId);

            List<CompetitionRoundScore> competitionRoundScoresList = refereeMarkRepository.GetTopCompetitionRoundsByAverageScore(competitionRoundInfoList, top);
            return competitionRoundScoresList;
        }

    }
}
