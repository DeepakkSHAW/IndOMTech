using System.ComponentModel.DataAnnotations;

namespace IndOMTech.Shared.Models
{
    public class ContactUs
    {
        public int ContactUsId { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public string EMail { get; set; }
        public string? Message { get; set; }

        public DateTime InDate { get; set; } = DateTime.UtcNow;
    }

    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required] [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 - 30 characters long.")]
        //[MinLength(5, ErrorMessage = "Too short!")]
        public string Name { get; set; }
        public string? LastName { get; set; }

        [Required] [EmailAddress]
        public string Email { get; set; }

        [Required] [MaxLength(100, ErrorMessage = "Too long!")]
        public string Subject { get; set; }

        public DateTime InDate { get; set; }

    }
}