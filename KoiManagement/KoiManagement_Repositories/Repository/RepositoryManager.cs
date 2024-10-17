using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly KoiManagementContext context;

		public RepositoryManager(KoiManagementContext context)
		{
			this.context = context;
		}
		public Task Save() => context.SaveChangesAsync();
	}
}
