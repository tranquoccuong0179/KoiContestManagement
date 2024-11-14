using KoiManagement_BusinessObjects;

namespace KoiManagement_Repositories.IRepository
{
    public interface ICriteriaPointRepository
    {
        public List<CriteriaPoint> GetCriteriaPoints();
        public CriteriaPoint GetCriteriaPoint(string id);
        public bool AddCriteriaPoint(CriteriaPoint criteriaPointNew, string refereeMarkId, string criteriaId);
        public bool UpdateCriteriaPoint(CriteriaPoint criteriaPointUpdate);
        public bool DeleteCriteriaPoint(CriteriaPoint criteriaPointDelete);
    }
}
