using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.IRepository
{
    public interface ICriteriaPointRepository
    {
        public List<CriteriaPoint> GetCriteriaPoints();
        public CriteriaPoint GetCriteriaPoint(string id);
        public bool AddCriteriaPoint(CriteriaPoint criteriaPointNew);
        public bool UpdateCriteriaPoint(CriteriaPoint criteriaPointUpdate);
        public bool DeleteCriteriaPoint(CriteriaPoint criteriaPointDelete);
    }
}
