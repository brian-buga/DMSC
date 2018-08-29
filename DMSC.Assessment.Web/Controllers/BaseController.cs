namespace DMSC.Assessment.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    
    public class BaseController : Controller
    {       
        public int UserId
        {
            get {
                var id = User?.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
                return id != null ? int.Parse(id) : 0; }
        }

        public string UserName
        {
            get
            {
                var email = User?.Claims.FirstOrDefault(x => x.Type == "email")?.Value;
                return email == null ? string.Empty : email;
            }
        }       
    }
}