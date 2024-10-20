using AutoMapper;
using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.AuthenticationServices.DTO
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserForRegistrationDto, User>();
			CreateMap<User, UserForReturnDto>();
		}
	}
}
