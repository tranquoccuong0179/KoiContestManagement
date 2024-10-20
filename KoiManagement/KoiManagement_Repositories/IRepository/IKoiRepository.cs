using KoiManagement_BusinessObjects;

namespace KoiManagement_Repositories.IRepository
{
	public interface IKoiRepository
	{
		public Task<List<Koi>> GetAll();
		public Task<List<Koi>> GetByUserId(string userId);
		public Task<Koi?> GetById(string koiId, string userId);
		public Task<bool> Create(Koi koi);
		public Task<bool> Update(Koi koi);
		public Task<bool> Delete(Koi koi);
	}
}
