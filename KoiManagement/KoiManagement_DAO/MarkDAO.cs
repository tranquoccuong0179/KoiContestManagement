using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_DAO
{
    public class MarkDAO
    {
        private KoiManagementContext context;
        private static MarkDAO instance;

        public static MarkDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MarkDAO();
                }
                return instance;
            }
        }

        public MarkDAO()
        {
            context = new KoiManagementContext();
        }

        public List<Mark> GetMarks()
        {
            return context.Marks.Include(x => x.CompetitionRound).ToList();
        }

        public Mark GetMark(string id)
        {
            var entity = context.Marks.SingleOrDefault(m => m.Id.Equals(id));
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }


        public bool AddMark(Mark mark)
        {
            bool result = false;
            Mark newMark = GetMark(mark.Id);
            try
            {
                if (newMark == null)
                {
                    context.Marks.Add(mark);
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
        public bool DeleteMark(Mark mark)
        {
            bool result = false;
            Mark newMark = GetMark(mark.Id);
            try
            {
                if (newMark != null)
                {
                    context.Marks.Remove(mark);
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

        public bool UpdateMark(Mark mark)
        {
            bool result = false;
            Mark newMark = GetMark(mark.Id);
            try
            {
                if (newMark != null)
                {
                    context.Entry<Mark>(mark).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
