using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
    public class CriteriaRepository : ICriteriaRepository
    {
        public bool AddCriteria(Criteria criteria) => CriteriaDAO.Instance.AddCriteria(criteria);

        public bool DeleteCriteria(Criteria criteria) => CriteriaDAO.Instance.DeleteCriteria(criteria);

        public Criteria GetCriteria(string id) => CriteriaDAO.Instance.GetCriteria(id);

        public List<Criteria> GetCriterias() => CriteriaDAO.Instance.GetCriterias();

        public bool UpdateCriteria(Criteria criteria) => CriteriaDAO.Instance.UpdateCriteria(criteria);
    }
}
