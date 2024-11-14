using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface IResultService
    {
        public List<Result> GetResults();
        public Result GetResultById(string id);
        public bool AddResult(Result result);
        public bool DeleteResult(Result result);
        public bool UpdateResult(Result result);
    }
}
