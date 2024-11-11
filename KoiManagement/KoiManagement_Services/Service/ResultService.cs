using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.Service
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository resultRepository;

        public ResultService(IResultRepository resultRepository)
        {
            this.resultRepository = resultRepository;
        }

        public bool AddResult(Result result)
        {
            return resultRepository.AddResult(result);
        }

        public bool DeleteResult(Result result)
        {
            return resultRepository.DeleteResult(result);
        }

        public Result GetResultById(string id)
        {
            return resultRepository.GetResultById(id);
        }

        public List<Result> GetResults()
        {
            return resultRepository.GetResults();
        }

        public bool UpdateResult(Result result)
        {
            return resultRepository.UpdateResult(result);
        }
    }
}
