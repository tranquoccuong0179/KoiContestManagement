using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_DAO
{
    public class RefereeMarkDAO
    {
        private KoiManagementContext context;
        private static RefereeMarkDAO instance;

        public RefereeMarkDAO()
        {
            context = new KoiManagementContext();
        }

        public static RefereeMarkDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RefereeMarkDAO();
                }
                return instance;
            }
        }

        public List<RefereeMark> GetRefereeMarks()
        {
            return context.RefereeMarks.Where(r => r.Active == true).ToList();
        }

        public RefereeMark GetRefereeMark(string id)
        {

            var entity = context.RefereeMarks.SingleOrDefault(m => m.Id.Equals(id) && m.Active == true);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public bool AddRefereeMark(RefereeMark refereeMarkNew)
        {
            bool result = false;
            RefereeMark refereeMark = GetRefereeMark(refereeMarkNew.Id);
            try
            {
                if (refereeMark == null)
                {
                    context.RefereeMarks.Add(refereeMarkNew);
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
        public bool UpdateRefereeMark(RefereeMark refereeMarkUpdate)
        {
            bool result = false;
            RefereeMark refereeMark = GetRefereeMark(refereeMarkUpdate.Id);
            try
            {
                if (refereeMark != null)
                {
                    context.Entry<RefereeMark>(refereeMarkUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public bool DeleteRefereeMark(RefereeMark refereeMarkDelete)
        {
            bool result = false;
            RefereeMark? existedRefereeMark = GetRefereeMark(refereeMarkDelete.Id);
            try
            {
                if (existedRefereeMark != null)
                {
                    existedRefereeMark.Active = false;
                    context.Entry<RefereeMark>(existedRefereeMark).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
