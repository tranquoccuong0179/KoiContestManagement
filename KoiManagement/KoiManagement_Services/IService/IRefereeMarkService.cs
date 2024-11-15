using KoiManagement_BusinessObjects;
using KoiManagement_DAO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.IService
{
    public interface IRefereeMarkService
    {
        public List<RefereeMark> GetRefereeMarks();
        public RefereeMark GetRefereeMark(string id);
        public bool AddRefereeMark(RefereeMark refereeMarkNew);
        public bool UpdateRefereeMark(RefereeMark refereeMarkUpdate);
        public bool DeleteRefereeMark(RefereeMark refereeMarkDelete);
        public List<CompetitionRoundScore> GetTopCompetitionRoundScoreByCRIdnRId(string competitionCategoryId, string roundId, int top);
    }
}
