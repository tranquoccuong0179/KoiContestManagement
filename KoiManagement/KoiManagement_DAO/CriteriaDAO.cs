using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_DAO
{
    public class CriteriaDAO
    {
        private KoiManagementContext context;
        private static CriteriaDAO instance;
        public CriteriaDAO()
        {
            context = new KoiManagementContext();
        }
        public static CriteriaDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CriteriaDAO();
                }
                return instance;
            }
        }
        public List<Criteria> GetCriterias()
        {
            return context.Criteria.ToList();
        }

        public Criteria? GetCriteria(string id)
        {
            return context.Criteria.SingleOrDefault(c => c.Id.Equals(id));
        }

        public bool AddCriteria(Criteria criteria)
        {
            bool result = false;
            Criteria? existedCriteria = GetCriteria(criteria.Id);
            try
            {
                if (existedCriteria == null)
                {
                    context.Criteria.Add(criteria);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool UpdateCriteria(Criteria criteria)
        {
            bool result = false;
            Criteria? existedCriteria = GetCriteria(criteria.Id);
            try
            {
                if (existedCriteria != null)
                {
                    context.Entry<Criteria>(criteria).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool DeleteCriteria(Criteria criteria)
        {
            bool result = false;
            Criteria? existedCriteria = GetCriteria(criteria.Id);
            try
            {
                if (existedCriteria != null)
                {
                    context.Criteria.Remove(existedCriteria);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
