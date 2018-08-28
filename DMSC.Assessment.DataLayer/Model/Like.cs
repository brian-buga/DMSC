using System.ComponentModel.DataAnnotations.Schema;

namespace DMSC.Assessment.Data.Model
{   
    public  class Like : EntityBase
    {
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
       
    }
}
