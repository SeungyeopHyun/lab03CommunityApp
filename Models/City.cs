using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityApp.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        public string? CityName { get; set; }

        [Required]
        public int Population { get; set; }

        [Required]
        public string? ProvinceCode { get; set; }

        [ForeignKey("ProvinceCode")]
        public Province? Province { get; set; }
    }
}
