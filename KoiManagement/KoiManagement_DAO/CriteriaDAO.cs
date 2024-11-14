using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;
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
            return context.Criteria.Where(c => c.Active == true).ToList();
        }

        public Criteria? GetCriteria(string id)
        {
            var entity = context.Criteria.SingleOrDefault(m => m.Id.Equals(id) && m.Active == true);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public bool AddCriteria(Criteria criteria)
        {
            bool result = false;
            try
            {
                criteria.Active = true;
                criteria.Id = Guid.NewGuid().ToString();
                criteria.CreateAt = DateTime.Now;
                criteria.UpdateAt = DateTime.Now;
                context.Criteria.Add(criteria);
                context.SaveChanges();
                result = true;

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
                    context.Entry<Criteria>(criteria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    existedCriteria.Active = false;
                    existedCriteria.DeleteAt = DateTime.Now;
                    context.Entry<Criteria>(existedCriteria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
