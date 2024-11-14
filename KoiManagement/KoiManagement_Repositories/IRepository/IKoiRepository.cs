using KoiManagement_BusinessObjects;
using KoiManagement_DAO;

namespace KoiManagement_Repositories.IRepository
{
    public interface IKoiRepository
    {
        public Task<List<Koi>> GetAll();
        public Koi GetKoiById(string? koiId);
        public Task<List<Koi>> GetByUserIdActive(string userId);
        public Task<List<Koi>> GetByUserId(string userId);
        public Task<Koi?> GetById(string? koiId, string? userId);
        public Task<bool> Create(Koi koi);
        public Task<bool> Update(Koi koi);
        public Task<bool> Delete(Koi koi);
        public Task<KoiCompetitionVM> GetAllWithKois(string competitionRoundId);
    }
}
