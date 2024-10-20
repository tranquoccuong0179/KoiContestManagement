using KoiManagement_Services.AuthenticationServices;
using KoiManagement_Services.KoiServices;

namespace KoiManagement_Service.IService
{
	public interface IServiceManager
	{
		IAuthenticationService AuthenticationService { get; }
		IKoiService KoiService { get; }
	}
}
