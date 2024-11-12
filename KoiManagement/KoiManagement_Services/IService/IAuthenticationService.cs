using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Identity;

namespace KoiManagement_Services.IService
{
	public interface IAuthenticationService
	{
		public Task<UserForReturnDto?> AuthenticateUser(UserForAuthenticationDto userForAuthenticationDto);
		public Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
		public Task<UserForReturnDto?> GetUserById(string userId);
		public Task<List<UserForReturnDto>> GetAllUsersExcepAdmin();
		public Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto);
		public Task<IdentityResult> UpdateUser(string userId, UserForUpdateProfileDto userForUpdateProfile);
		public Task<IdentityResult> UpdateActiveStatus(string userId);
	}
}
