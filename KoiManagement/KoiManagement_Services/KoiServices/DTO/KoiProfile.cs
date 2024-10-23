using AutoMapper;
using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.KoiServices.DTO
{
	public class KoiProfile : Profile
	{
		public KoiProfile()
		{
			CreateMap<KoiForCreationDto, Koi>().ForSourceMember(c => c.File, opt => opt.DoNotValidate());
			CreateMap<KoiForUpdateDto, Koi>().ForSourceMember(c => c.File, opt => opt.DoNotValidate());
			CreateMap<Koi, KoiForReturnDto>();

		}
	}
}
