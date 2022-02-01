using System.ComponentModel.DataAnnotations;

namespace SkeletonNetCore.Services.Models
{
    public class Contact
    {
        public int intId { get; set; }

        [Required]
        public string strFirstName { get; set; }
        
        [Required]
        public string strLastName { get; set; }

        [Required]
        public string strCompany { get; set; }

        [Required]
        public string strPhoneNumber { get; set; }

        [Required, RegularExpression("/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$/")]
        public string strEmail { get; set; }
    }
}