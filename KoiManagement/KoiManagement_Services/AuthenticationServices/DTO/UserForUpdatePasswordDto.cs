using System.ComponentModel.DataAnnotations;

namespace KoiManagement_Services.AuthenticationServices.DTO
{
	public record UserForUpdatePasswordDto
	{
		[Required]
		public string OldPassword { get; init; }
		[Required]
		public string NewPassword { get; init; }
		[Required]
		[Compare("NewPassword", ErrorMessage = "Password and confirmation password do not match.")]
		public string ConfirmPassword { get; init; }
	}
}
