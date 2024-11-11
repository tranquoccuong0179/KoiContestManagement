using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
    public class MarkRepository : IMarkRepository
    {
        public List<Mark> GetMarks() => MarkDAO.Instance.GetMarks();
        public Mark GetMarkById(string id) => MarkDAO.Instance.GetMark(id);
        public bool AddMark(Mark mark) => MarkDAO.Instance.AddMark(mark);
        public bool DeleteMark(Mark mark) => MarkDAO.Instance.DeleteMark(mark);
        public bool UpdateMark(Mark mark) => MarkDAO.Instance.UpdateMark(mark);
    }
}
