using KoiManagement_BusinessObjects;
using KoiManagement_DAO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.IRepository
{
    public interface IRefereeMarkRepository
    {
        public List<RefereeMark> GetRefereeMarks();
        public RefereeMark GetRefereeMark(string id);
        public bool AddRefereeMark(RefereeMark refereeMarkNew);
        public bool UpdateRefereeMark(RefereeMark refereeMarkUpdate);
        public bool DeleteRefereeMark(RefereeMark refereeMarkDelete);
        public RefereeMark? GetExistRefereeMark(string competitionId, string userId);
        public List<CompetitionRoundScore> GetTopCompetitionRoundsByAverageScore(
  List<CompetitionRoundInfoDTO> competitionRoundInfoList, int top);
    }
}
