using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Services.IService;

namespace KoiManagement_Services.Service
{
    public class CriteriaPointService : ICriteriaPointService
    {
        private readonly ICriteriaPointRepository pointCriteria;
        public CriteriaPointService(ICriteriaPointRepository pointRepository)
        {
            this.pointCriteria = pointRepository;
        }
        public bool AddCriteriaPoint(CriteriaPoint criteriaPointNew, string refereeMarkId, string criteriaId) => pointCriteria.AddCriteriaPoint(criteriaPointNew, refereeMarkId, criteriaId);
        public bool DeleteCriteriaPoint(CriteriaPoint criteriaPointDelete) => pointCriteria.DeleteCriteriaPoint(criteriaPointDelete);

        public CriteriaPoint GetCriteriaPoint(string id) => pointCriteria.GetCriteriaPoint(id);

        public List<CriteriaPoint> GetCriteriaPoints() => pointCriteria.GetCriteriaPoints();

        public bool UpdateCriteriaPoint(CriteriaPoint criteriaPointUpdate) => pointCriteria.UpdateCriteriaPoint(criteriaPointUpdate);
    }
}
