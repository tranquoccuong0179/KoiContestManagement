using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace KoiManagement_Services.KoiServices.DTO
{
    public record KoiForCreationDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Type { get; init; }
        [Required]
        public string Variety { get; init; }
        [Required]
        public DateTime DateOfBirth { get; init; }
        [Required]
        public double Size { get; init; }
        [Required]
        public IFormFile File { get; init; }
        [Required]
        public string UserId { get; init; }
    }
}
