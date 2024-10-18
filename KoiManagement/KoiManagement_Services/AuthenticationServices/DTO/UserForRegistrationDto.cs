using System.ComponentModel.DataAnnotations;

namespace KoiManagement_Services.AuthenticationServices.DTO
{
	public record UserForRegistrationDto
	{
		[Required]
		public string UserName { get; init; }
		[Required]
		[MaxLength(100)]
		public string FullName { get; init; }
		[Required]
		public string Password { get; init; }
		[Required]
		[Compare("Password")]
		public string ConfirmPassword { get; init; }
	}
}
