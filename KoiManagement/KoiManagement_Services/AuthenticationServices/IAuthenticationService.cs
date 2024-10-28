using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Identity;

namespace KoiManagement_Services.AuthenticationServices
{
	public interface IAuthenticationService
	{
		public Task<UserForReturnDto?> AuthenticateUser(UserForAuthenticationDto userForAuthenticationDto);
		public Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
		public Task<UserForReturnDto?> GetUserById(string userId);
		Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto);
	}
}
