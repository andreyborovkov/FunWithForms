
using System.ComponentModel.DataAnnotations;

namespace FunWithForms.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(1900, 2019)]
        public int Year { get; set; }
    }
}
