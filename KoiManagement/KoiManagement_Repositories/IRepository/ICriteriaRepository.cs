using KoiManagement_BusinessObjects;

namespace KoiManagement_Repositories.IRepository
{
    public interface ICriteriaRepository
    {
        public List<Criteria> GetCriterias();
        public Criteria GetCriteria(string id);
        public bool AddCriteria(Criteria criteria);
        public bool DeleteCriteria(Criteria criteria);
        public bool UpdateCriteria(Criteria criteria);
    }
}

