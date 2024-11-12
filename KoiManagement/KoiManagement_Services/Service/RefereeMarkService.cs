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
    public class RefereeMarkService : IRefereeMarkService
    {
        private readonly IRefereeMarkRepository refereeMarkRepository;
        public RefereeMarkService(IRefereeMarkRepository refereeMarkRepository)
        {
            this.refereeMarkRepository = refereeMarkRepository;
        }

        public bool AddRefereeMark(RefereeMark refereeMarkNew) => refereeMarkRepository.AddRefereeMark(refereeMarkNew);

        public bool DeleteRefereeMark(RefereeMark refereeMarkDelete) => refereeMarkRepository.DeleteRefereeMark(refereeMarkDelete);

        public RefereeMark GetRefereeMark(string id) => refereeMarkRepository.GetRefereeMark(id);

        public List<RefereeMark> GetRefereeMarks() => refereeMarkRepository.GetRefereeMarks();

        public bool UpdateRefereeMark(RefereeMark refereeMarkUpdate) => refereeMarkRepository.UpdateRefereeMark(refereeMarkUpdate);
    }
}
