using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkeletonNetCore.Models
{
    [Table("business_quote")]
    public class ContactDto
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column("first_name")]
        public string firstName { get; set; }

        [Column("last_name")]
        public string lastName { get; set; }

        [Column("company")]
        public string company { get; set; }

        [Column("phone_number")]
        public string phoneNumber { get; set; }

        [Column("email")]
        public string email { get; set; }
    }
}
