using KoiManagement_Repository.IRepository;
using KoiManagement_Service.IService;
using Microsoft.Extensions.Configuration;

namespace KoiManagement_Service.Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IConfiguration configuration;

		public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration)
		{
			this.repositoryManager = repositoryManager;
			this.configuration = configuration;
		}
	}
}
