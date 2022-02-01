using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkeletonNetCore.Models
{
    [Table("product")]
    public class ProductDto
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column("name")]
        public string name { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("img")]
        public string img { get; set; }

        [Column("review")]
        public int review { get; set; }

        public ProductDto()
        {
        }
    }
}
