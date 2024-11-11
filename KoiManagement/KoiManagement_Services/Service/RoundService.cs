using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Repositories.Repository;
using KoiManagement_Services.IService;

namespace KoiManagement_Services.Service
{
    public class RoundService : IRoundService
    {
        private IRoundRepository _roundRepository;
        public RoundService()
        {
            _roundRepository = new RoundRepository();
        }
        public List<Round> GetRounds() => _roundRepository.GetRounds();
        public Round? GetRound(string id) => _roundRepository.GetRound(id);
        public bool AddRound(Round round) => _roundRepository.AddRound(round);
        public bool UpdateRound(Round round) => _roundRepository.UpdateRound(round);
        public bool DeleteRound(Round round) => _roundRepository.DeleteRound(round);

    }
}
