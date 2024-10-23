using KoiManagement_Services.KoiServices.DTO;

namespace KoiManagement_Services.KoiServices
{
	public interface IKoiService
	{
		public Task<List<KoiForReturnDto>> GetAll();
		public Task<List<KoiForReturnDto>> GetByUserId(string userId);
		public Task<KoiForReturnDto?> GetById(string koiId, string userId);
		public Task<bool> Create(KoiForCreationDto koiForCreationDto);
		public Task<bool> Update(KoiForUpdateDto koiForUpdateDto);
		public Task<bool> Delete(string userId, string koiId);
	}
}
