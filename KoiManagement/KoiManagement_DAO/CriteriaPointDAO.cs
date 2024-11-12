using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_DAO
{
    public class CriteriaPointDAO
    {
        private KoiManagementContext context;
        private static CriteriaPointDAO instance;

        public CriteriaPointDAO()
        {
            context = new KoiManagementContext();
        }

        public static CriteriaPointDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CriteriaPointDAO();
                }
                return instance;
            }
        }

        public List<CriteriaPoint> GetCriteriaPoints()
        {
            return context.CriteriaPoints.Where(m => m.Active == true).Include(m => m.Criteria).Include(m => m.RefereeMark).ThenInclude(rf => rf.User).ToList();
        }

        public CriteriaPoint GetCriteriaPoint(string id)
        {

            var entity = context.CriteriaPoints.SingleOrDefault(m => m.Id.Equals(id) && m.Active == true);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public bool AddCriteriaPoint(CriteriaPoint criteriaPointNew)
        {
            bool result = false;
            CriteriaPoint candidateProfile = GetCriteriaPoint(criteriaPointNew.Id);
            try
            {
                if (candidateProfile == null)
                {
                    context.CriteriaPoints.Add(criteriaPointNew);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public bool UpdateCriteriaPoint(CriteriaPoint criteriaPointUpdate)
        {
            bool result = false;
            CriteriaPoint criteriaPoint = GetCriteriaPoint(criteriaPointUpdate.Id);
            try
            {
                if (criteriaPoint != null)
                {
                    context.Entry<CriteriaPoint>(criteriaPointUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public bool DeleteCriteriaPoint(CriteriaPoint criteriaPointDelete)
        {
            bool result = false;
            CriteriaPoint? existedCriteriaPoint = GetCriteriaPoint(criteriaPointDelete.Id);
            try
            {
                if (existedCriteriaPoint != null)
                {
                    existedCriteriaPoint.Active = false;
                    context.Entry<CriteriaPoint>(existedCriteriaPoint).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
    }
}
