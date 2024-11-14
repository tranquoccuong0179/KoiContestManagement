using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_DAO
{
    public class ResultDAO
    {
        private KoiManagementContext context;
        private static ResultDAO instance;

        public static ResultDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResultDAO();
                }
                return instance;
            }
        }

        public ResultDAO()
        {
            context = new KoiManagementContext();
        }

        public List<Result> GetResults()
        {
            return context.Results.Include(x => x.Registration).ToList();
        }

        public Result GetResult(string id)
        {
            var entity = context.Results.SingleOrDefault(m => m.Id.Equals(id));
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }


        public bool AddResult(Result resultE)
        {
            bool result = false;
            Result newResultE = GetResult(resultE.Id);
            try
            {
                if (newResultE == null)
                {
                    context.Results.Add(resultE);
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
        public bool DeleteResult(Result resultE)
        {
            bool result = false;
            Result newResultE = GetResult(resultE.Id);
            try
            {
                if (newResultE != null)
                {
                    context.Results.Remove(resultE);
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

        public bool UpdateResult(Result resultE)
        {
            bool result = false;
            Result newResultE = GetResult(resultE.Id);
            try
            {
                if (newResultE != null)
                {
                    context.Entry<Result>(resultE).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
