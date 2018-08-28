namespace DMSC.Assessment.Web.Services
{
    using DMSC.Assessment.Data.Model;
    using System.Security.Claims;

    public interface IUserManager
    {
        ClaimsPrincipal Principal(User user);
    }
}
