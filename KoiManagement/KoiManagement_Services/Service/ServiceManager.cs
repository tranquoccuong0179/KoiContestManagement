using AutoMapper;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Service.IService;
using Microsoft.Extensions.Configuration;

namespace KoiManagement_Service.Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IConfiguration configuration;
		private readonly IMapper mapper;

		public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.configuration = configuration;
			this.mapper = mapper;
		}
	}
}
