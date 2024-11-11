using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace KoiManagement_Services.KoiServices.DTO
{
    public class KoiForUpdateDto
    {
        [Required]
        public string Id { get; init; }
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
        public IFormFile? File { get; init; }
        [Required]
        public string UserId { get; init; }
    }
}
