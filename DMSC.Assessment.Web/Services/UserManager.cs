namespace DMSC.Assessment.Web.Services
{
    using DMSC.Assessment.Data.Model;

    using Microsoft.AspNetCore.Authentication.Cookies;

    using System.Collections.Generic;
    using System.Security.Claims;

    public class UserManager : IUserManager
    {
        public ClaimsPrincipal Principal(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(this.PrepareUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            return principal;
        }

        #region private function

        private IEnumerable<Claim> PrepareUserClaims(User user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim("firstName", user.FirstName));
            claims.Add(new Claim("email", user.Email));
            claims.AddRange(this.PrepareUserRoleClaims(user));
            return claims;
        }

        private IEnumerable<Claim> PrepareUserRoleClaims(User user)
        {
            List<Claim> claims = new List<Claim>();
                      
            claims.Add(new Claim("role", user.Role));
            return claims;
        }

        #endregion
    }
}
