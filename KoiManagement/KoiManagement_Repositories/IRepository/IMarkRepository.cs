using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.IRepository
{
    public interface IMarkRepository
    {
        public List<Mark> GetMarks();
        public Mark GetMarkById(string id);
        public bool AddMark(Mark mark);
        public bool DeleteMark(Mark mark);
        public bool UpdateMark(Mark mark);
    }
}
