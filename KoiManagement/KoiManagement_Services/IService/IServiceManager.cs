using KoiManagement_Services.AuthenticationServices;

namespace KoiManagement_Service.IService
{
	public interface IServiceManager
	{
		IAuthenticationService AuthenticationService { get; }
	}
}
