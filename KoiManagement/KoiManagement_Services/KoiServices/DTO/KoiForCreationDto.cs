using Microsoft.AspNetCore.Http;

namespace KoiManagement_Services.KoiServices.DTO
{
	public record KoiForCreationDto
	{
		public string Name { get; init; }
		public string Type { get; init; }
		public string Variety { get; init; }
		public DateTime DateOfBirth { get; init; }
		public double Size { get; init; }
		public IFormFile File { get; init; }
	}
}
