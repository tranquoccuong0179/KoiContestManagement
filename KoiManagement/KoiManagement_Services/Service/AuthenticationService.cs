using AutoMapper;
using KoiManagement_BusinessObjects;
using KoiManagement_BusinessObjects.Constants;
using KoiManagement_Services.AuthenticationServices.DTO;
using KoiManagement_Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_Services.Service
{
	public sealed class AuthenticationService : IAuthenticationService
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly RoleManager<IdentityRole> roleManager;

		public AuthenticationService(UserManager<User> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.roleManager = roleManager;
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

		public async Task<List<UserForReturnDto>> GetAllUsersExcepAdmin()
		{
			var users = await userManager.Users.ToListAsync();
			var nonAdminUser = new List<User>();
			foreach (var user in users)
			{
				var roles = await userManager.GetRolesAsync(user);
				if (!roles.Contains(Role.Admin))
				{
					nonAdminUser.Add(user);
				}
			}
			var returnUser = mapper.Map<List<UserForReturnDto>>(nonAdminUser);
			for (int i = 0; i < returnUser.Count; i++)
			{
				var roles = await userManager.GetRolesAsync(nonAdminUser[i]);
				returnUser[i].Roles = roles.ToList();
			}
			return returnUser;
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
				await userManager.AddToRoleAsync(user, Role.Contestant);
			}

			return result;
		}


		public async Task<IdentityResult> UpdateActiveStatus(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			user.Active = !user.Active;
			user.DeleteAt = DateTime.Now;
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
