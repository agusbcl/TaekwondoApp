using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual IdentityRole Role { get; set; }
    }
}
