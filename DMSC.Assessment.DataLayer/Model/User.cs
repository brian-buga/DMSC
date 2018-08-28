namespace DMSC.Assessment.Data.Model
{   
    using System.Collections.Generic;

    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
