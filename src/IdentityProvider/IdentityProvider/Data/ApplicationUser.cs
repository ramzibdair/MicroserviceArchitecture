using Microsoft.AspNetCore.Identity;

namespace IdentityProvider.Data
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CareerStartedDate { get; set; }
        public string? FullName { get; set; }
    }
}
