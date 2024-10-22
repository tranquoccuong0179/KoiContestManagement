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
            throw new NotImplementedException();
        }

        public bool DeleteMark(Mark mark)
        {
            throw new NotImplementedException();
        }

        public Mark GetMarkById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Mark> GetMarks()
        {
            throw new NotImplementedException();
        }

        public bool UpdateMark(Mark mark)
        {
            throw new NotImplementedException();
        }
    }
}
