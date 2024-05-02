using System.ComponentModel.DataAnnotations;

namespace TriantaWeb.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage = "Code has to be a minimun of 3 characters")]
        [MaxLength(100)]
        public string Code { get; set;}
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be a minimun of 3 characters")]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
