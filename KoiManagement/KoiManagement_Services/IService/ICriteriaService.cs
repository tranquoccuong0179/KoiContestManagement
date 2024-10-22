using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
