using Microsoft.AspNetCore.Identity;


namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string ImgUrl { get; set; }
        public Authority? Authority { get; set; }
        public School? School { get; set; }
        public Professor? Professor { get; set; }

    }
}
