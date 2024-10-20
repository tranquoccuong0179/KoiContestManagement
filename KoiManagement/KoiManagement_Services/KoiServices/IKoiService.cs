using KoiManagement_Services.KoiServices.DTO;

namespace KoiManagement_Services.KoiServices
{
	public interface IKoiService
	{
		public Task<List<KoiForReturnDto>> GetAll();
		public Task<List<KoiForReturnDto>> GetByUserId(string userId);
		public Task<KoiForReturnDto?> GetById(string koiId, string userId);
		public Task<bool> Create(KoiForCreationDto koiForCreationDto);
		public Task<bool> Update(KoiForUpdateDto koiForUpdateDto, string userId, string koiId);
		public Task<bool> Delete(KoiForDeleteDto koiForDeleteDto, string userId, string koiId);
	}
}
