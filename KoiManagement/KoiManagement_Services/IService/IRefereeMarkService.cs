using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface IRefereeMarkService
    {
        public List<RefereeMark> GetRefereeMarks();
        public RefereeMark GetRefereeMark(string id);
        public bool AddRefereeMark(RefereeMark refereeMarkNew);
        public bool UpdateRefereeMark(RefereeMark refereeMarkUpdate);
        public bool DeleteRefereeMark(RefereeMark refereeMarkDelete);
    }
}
