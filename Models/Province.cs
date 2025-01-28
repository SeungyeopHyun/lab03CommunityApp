using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityApp.Models
{
    public class Province
    {
        [Key]
        [Required]
        public string? ProvinceCode { get; set; }

        [Required]
        public string? ProvinceName { get; set; }

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
