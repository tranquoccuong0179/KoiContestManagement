using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Services.IService;

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
