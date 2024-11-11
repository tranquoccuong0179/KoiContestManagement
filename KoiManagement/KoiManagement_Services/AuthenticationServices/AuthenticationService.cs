using AutoMapper;
using KoiManagement_BusinessObjects;
using KoiManagement_BusinessObjects.Constants;
using KoiManagement_Services.AuthenticationServices.DTO;
using Microsoft.AspNetCore.Identity;

namespace KoiManagement_Services.AuthenticationServices
{
	internal sealed class AuthenticationService : IAuthenticationService
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;

		public AuthenticationService(UserManager<User> userManager, IMapper mapper)
		{
			this.userManager = userManager;
			this.mapper = mapper;
		}
		public async Task<UserForReturnDto?> AuthenticateUser(UserForAuthenticationDto userForAuthenticationDto)
		{
			if (userForAuthenticationDto is null || userForAuthenticationDto.UserName is null || userForAuthenticationDto.Password is null) return null;
			var user = await userManager.FindByNameAsync(userForAuthenticationDto.UserName);
			if (user is null) return null;
			var result = await userManager.CheckPasswordAsync(user, userForAuthenticationDto.Password) && user.Active;
			if (result)
			{
				var roles = await userManager.GetRolesAsync(user);
				var returnUser = mapper.Map<UserForReturnDto>(user);
				returnUser.Roles = roles.ToList();
				return returnUser;
			}
			return null;
		}

		public async Task<UserForReturnDto?> GetUserById(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			if (user is null) return null;
			var roles = await userManager.GetRolesAsync(user);
			var returnUser = mapper.Map<UserForReturnDto>(user);
			returnUser.Roles = roles.ToList();
			return returnUser;
		}

		public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
		{
			var user = mapper.Map<User>(userForRegistrationDto);
			user.Active = true;
			user.CreateAt = DateTime.Now;

			var result = await userManager.CreateAsync(user, userForRegistrationDto.Password);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, Role.Constestant);
			}

			return result;
		}

		public async Task<IdentityResult> UpdateActiveStatus(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			user.Active = !user.Active;
			user.UpdateAt = DateTime.Now;
			return await userManager.UpdateAsync(user);
		}

		public async Task<IdentityResult> UpdateUser(string userId, UserForUpdateProfileDto userForUpdateProfile)
		{
			var user = await userManager.FindByIdAsync(userId);

			mapper.Map(userForUpdateProfile, user);
			user.UpdateAt = DateTime.Now;
			return await userManager.UpdateAsync(user);
		}

		public async Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto)
		{
			var user = await userManager.FindByIdAsync(userId);
			user.UpdateAt = DateTime.Now;
			return await userManager.ChangePasswordAsync(user, userForUpdatePasswordDto.OldPassword, userForUpdatePasswordDto.NewPassword);
		}
	}
}
