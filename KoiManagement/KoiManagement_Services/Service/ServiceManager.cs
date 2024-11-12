using AutoMapper;
using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Service.IService;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace KoiManagement_Service.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IKoiService> _koiService;

        public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration, IMapper mapper, UserManager<User> userManager, IBlobService blobService, RoleManager<IdentityRole> roleManager)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, mapper, roleManager));
            _koiService = new Lazy<IKoiService>(() => new KoiService(repositoryManager, mapper, blobService));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IKoiService KoiService => _koiService.Value;
    }
}
