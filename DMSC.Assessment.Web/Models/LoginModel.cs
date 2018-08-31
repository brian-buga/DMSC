namespace DMSC.Assessment.Web.Model
{
    using System.ComponentModel.DataAnnotations;
    public class LoginModel
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        public string returnUrl { get; set; }
    }
}
