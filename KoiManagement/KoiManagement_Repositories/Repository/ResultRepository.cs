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
    public class ResultRepository : IResultRepository
    {
        public List<Result> GetResults() => ResultDAO.Instance.GetResults();
        public Result GetResultById(string id) => ResultDAO.Instance.GetResult(id);
        public bool AddResult(Result result) => ResultDAO.Instance.AddResult(result);
        public bool DeleteResult(Result result) => ResultDAO.Instance.DeleteResult(result);
        public bool UpdateResult(Result result) => ResultDAO.Instance.UpdateResult(result);
    }
}
