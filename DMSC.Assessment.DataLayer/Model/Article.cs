namespace DMSC.Assessment.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article : EntityBase
    {
        public string Title {get;set;}     
        public string Content { get; set; }
        public DateTime Published  { get; set; }
        public bool Active { get; set; }     
        public int UserId { get; set; }
        public virtual User Author { get; set; }       
        public virtual ICollection<Like> Likes { get; set; }
    }
}
