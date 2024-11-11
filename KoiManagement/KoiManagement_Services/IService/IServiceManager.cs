using KoiManagement_Services.AuthenticationServices;
using KoiManagement_Services.IService;

namespace KoiManagement_Service.IService
{
    public interface IServiceManager
	{
		IAuthenticationService AuthenticationService { get; }
		IKoiService KoiService { get; }
	}
}
