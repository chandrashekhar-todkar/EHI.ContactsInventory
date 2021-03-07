using System;
using System.ComponentModel.DataAnnotations;

namespace EHI.ContactsInvetory.Dto
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(200)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email!")]
        public string Email { get; set; }

        [MaxLength(50)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(8)]
        public string Status { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }
    }
}
