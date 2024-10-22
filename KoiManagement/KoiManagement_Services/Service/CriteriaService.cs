using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.Service
{
    public class CriteriaService : ICriteriaService
    {
        private ICriteriaRepository criteriaRepository;
        public CriteriaService(ICriteriaRepository criteriaRepository)
        {
            this.criteriaRepository = criteriaRepository;
        }
        public bool AddCriteria(Criteria criteria)
        {
            return criteriaRepository.AddCriteria(criteria);
        }

        public bool DeleteCriteria(Criteria criteria)
        {
            return criteriaRepository.DeleteCriteria(criteria);
        }

        public Criteria GetCriteria(string id)
        {
            return criteriaRepository.GetCriteria(id);
        }

        public List<Criteria> GetCriterias()
        {
            return criteriaRepository.GetCriterias();
        }

        public bool UpdateCriteria(Criteria criteria)
        {
            return criteriaRepository.UpdateCriteria(criteria);
        }
    }
}
