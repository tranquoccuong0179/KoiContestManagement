using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface ICriteriaService
    {
        public Criteria GetCriteria(string jobId);
        public List<Criteria> GetCriterias();
        public bool AddCriteria(Criteria criteria);
        public bool DeleteCriteria(Criteria criteria);
        public bool UpdateCriteria(Criteria criteria);
    }
}
