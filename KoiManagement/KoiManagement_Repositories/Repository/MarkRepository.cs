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
    public class MarkRepository : IMarkRepository
    {
        public List<Mark> GetMarks() => MarkDAO.Instance.GetMarks();
        public Mark GetMarkById(string id) => MarkDAO.Instance.GetMark(id);
        public bool AddMark(Mark mark) => MarkDAO.Instance.AddMark(mark);
        public bool DeleteMark(Mark mark) => MarkDAO.Instance.DeleteMark(mark);
        public bool UpdateMark(Mark mark) => MarkDAO.Instance.UpdateMark(mark);
    }
}
