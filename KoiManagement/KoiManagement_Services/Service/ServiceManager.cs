using AutoMapper;
using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace KoiManagement_Service.Service
{
	public class ServiceManager : IServiceManager
	{

		public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration, IMapper mapper, UserManager<User> userManager)
		{

		}
	}
}
