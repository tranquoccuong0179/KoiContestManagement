using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.Repository
{
    public class CriteriaPointRepository : ICriteriaPointRepository
    {
        public bool AddCriteriaPoint(CriteriaPoint criteriaPointNew, string refereeMarkId, string criteriaId) => CriteriaPointDAO.Instance.AddCriteriaPoint(criteriaPointNew, refereeMarkId,criteriaId);

        public bool DeleteCriteriaPoint(CriteriaPoint criteriaPointDelete) => CriteriaPointDAO.Instance.DeleteCriteriaPoint(criteriaPointDelete);

        public CriteriaPoint GetCriteriaPoint(string id) => CriteriaPointDAO.Instance.GetCriteriaPoint(id);

        public List<CriteriaPoint> GetCriteriaPoints() => CriteriaPointDAO.Instance.GetCriteriaPoints();

        public bool UpdateCriteriaPoint(CriteriaPoint criteriaPointUpdate) => CriteriaPointDAO.Instance.UpdateCriteriaPoint(criteriaPointUpdate);
    }
}
