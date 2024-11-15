using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_DAO.DTO;
using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
    public class RefereeMarkRepository : IRefereeMarkRepository
    {
        public bool AddRefereeMark(RefereeMark refereeMarkNew) => RefereeMarkDAO.Instance.AddRefereeMark(refereeMarkNew);

        public bool DeleteRefereeMark(RefereeMark refereeMarkDelete) => RefereeMarkDAO.Instance.DeleteRefereeMark(refereeMarkDelete);

        public RefereeMark? GetExistRefereeMark(string competitionId, string userId) => RefereeMarkDAO.Instance.GetExistRefereeMark(competitionId, userId);

        public RefereeMark GetRefereeMark(string id) => RefereeMarkDAO.Instance.GetRefereeMark(id);

        public List<RefereeMark> GetRefereeMarks() => RefereeMarkDAO.Instance.GetRefereeMarks();

        public bool UpdateRefereeMark(RefereeMark refereeMarkUpdate) => RefereeMarkDAO.Instance.UpdateRefereeMark(refereeMarkUpdate);

        public List<CompetitionRoundScore> GetTopCompetitionRoundsByAverageScore(
   List<CompetitionRoundInfoDTO> competitionRoundInfoList, int top) => RefereeMarkDAO.Instance.GetTopCompetitionRoundsByAverageScore(competitionRoundInfoList, top);
    }
}
