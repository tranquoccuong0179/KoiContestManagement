using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly Lazy<IKoiRepository> koiRepository;

		public RepositoryManager()
		{
			koiRepository = new Lazy<IKoiRepository>(() => new KoiRepository());
		}

		public IKoiRepository KoiRepository => koiRepository.Value;

	}
}
