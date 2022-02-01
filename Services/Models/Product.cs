using System.ComponentModel.DataAnnotations;

namespace SkeletonNetCore.Services.Models
{
    public class Product
    {
        public int id { get; set; }

        [Required, RegularExpression("/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$/")]
        public string name { get; set; }

        [Required, StringLength(50, MinimumLength = 0)]
        public string description { get; set; }

        [Required]
        public string img { get; set; }

        [Required, Range(1, 5)]
        public int review { get; set; }
        public Product()
        {
        }
    }
}