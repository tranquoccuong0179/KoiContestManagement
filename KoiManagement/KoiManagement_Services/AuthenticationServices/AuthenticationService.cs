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
	}
}
