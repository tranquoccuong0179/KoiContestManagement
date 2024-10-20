using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
	internal sealed class KoiRepository : IKoiRepository
	{

		public async Task<bool> Create(Koi koi) => await KoiDAO.Instance.Create(koi);

		public async Task<bool> Delete(Koi koi) => await KoiDAO.Instance.Delete(koi);

		public async Task<List<Koi>> GetAll() => await KoiDAO.Instance.GetAll();

		public async Task<Koi?> GetById(string koiId, string userId) => await KoiDAO.Instance.GetById(koiId, userId);

		public async Task<List<Koi>> GetByUserId(string userId) => await KoiDAO.Instance.GetByUserId(userId);

		public async Task<bool> Update(Koi koi) => await KoiDAO.Instance.Update(koi);
	}
}
