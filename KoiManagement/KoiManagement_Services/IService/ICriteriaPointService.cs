using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface ICriteriaPointService
    {
        public bool AddCriteriaPoint(CriteriaPoint criteriaPointNew, string refereeMarkId, string criteriaId);
        public bool DeleteCriteriaPoint(CriteriaPoint criteriaPointDelete);
        public CriteriaPoint GetCriteriaPoint(string id);
        public List<CriteriaPoint> GetCriteriaPoints();
        public bool UpdateCriteriaPoint(CriteriaPoint criteriaPointUpdate);
    }
}
