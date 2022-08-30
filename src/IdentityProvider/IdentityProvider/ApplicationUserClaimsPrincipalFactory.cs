using Microsoft.AspNetCore.Identity;
using IdentityProvider.Data;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace IdentityProvider
{
    public class ApplicationUserClaimsPrincipalFactory :
         UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options
            ) : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity>
            GenerateClaimsAsync(ApplicationUser user)
        {
      
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("CareerStarted",
                user.CareerStartedDate.ToShortDateString()));
            identity.AddClaim(new Claim("FullName",
                user.FullName));

            return identity;
        }
    }
}
