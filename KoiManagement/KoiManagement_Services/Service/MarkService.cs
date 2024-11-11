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
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository markRepository;

        public MarkService(IMarkRepository markRepository)
        {
            this.markRepository = markRepository;
        }

        public bool AddMark(Mark mark)
        {
            return markRepository.AddMark(mark);
        }

        public bool DeleteMark(Mark mark)
        {
            return markRepository.DeleteMark(mark);
        }

        public Mark GetMarkById(string id)
        {
            return markRepository.GetMarkById(id);
        }

        public List<Mark> GetMarks()
        {
            return markRepository.GetMarks();
        }

        public bool UpdateMark(Mark mark)
        {
            return markRepository.UpdateMark(mark);
        }
    }
}
