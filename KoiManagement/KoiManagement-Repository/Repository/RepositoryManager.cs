using KoiManagement_Business;
using KoiManagement_Repository.IRepository;

namespace KoiManagement_Repository.Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly Prn221Context context;

		public RepositoryManager(Prn221Context context)
		{
			this.context = context;
		}
		public Task Save() => context.SaveChangesAsync();
	}
}
