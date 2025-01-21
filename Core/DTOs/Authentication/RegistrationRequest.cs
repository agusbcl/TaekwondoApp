using System.ComponentModel.DataAnnotations;

namespace DTOs.Authentication
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string IdentificationType { get; set; }

        [Required]
        public string IdentificationNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        public string EmailConfirmed { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
