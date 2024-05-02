using System.ComponentModel.DataAnnotations;

namespace TriantaWeb.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? RegionImageUrl { get; set; }
    }
}
