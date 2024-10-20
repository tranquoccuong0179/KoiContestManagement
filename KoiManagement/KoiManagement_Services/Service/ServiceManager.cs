using AutoMapper;
using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Service.IService;
using KoiManagement_Services.AuthenticationServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace KoiManagement_Service.Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<IAuthenticationService> _authenticationService;

		public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration, IMapper mapper, UserManager<User> userManager)
		{
			_authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, mapper));
		}

		public IAuthenticationService AuthenticationService => _authenticationService.Value;
	}
}
