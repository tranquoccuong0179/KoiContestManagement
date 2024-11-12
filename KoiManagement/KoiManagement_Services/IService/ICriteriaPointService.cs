using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.IService
{
    public interface ICriteriaPointService
    {
        public bool AddCriteriaPoint(CriteriaPoint criteriaPointNew);
        public bool DeleteCriteriaPoint(CriteriaPoint criteriaPointDelete);
        public CriteriaPoint GetCriteriaPoint(string id);
        public List<CriteriaPoint> GetCriteriaPoints();
        public bool UpdateCriteriaPoint(CriteriaPoint criteriaPointUpdate);
    }
}
