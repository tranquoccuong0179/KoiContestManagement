using KoiManagement_BusinessObjects;
using KoiManagement_Services.KoiServices.DTO;

namespace KoiManagement_Services.IService
{
    public interface IKoiService
    {
        public Task<List<Koi>> GetAll();
        public Task<List<Koi>> GetByUserIdActive(string userId);
        public Task<List<Koi>> GetByUserId(string userId);
        public Task<Koi?> GetById(string koiId, string userId);
        public Task<bool> Create(KoiForCreationDto koiForCreationDto);
        public Task<bool> Update(KoiForUpdateDto koiForUpdateDto);
        public Task<bool> Delete(string userId, string koiId);
    }
}
