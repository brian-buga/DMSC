namespace DMSC.Assessment.Data.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    public  class Like : EntityBase
    {
        [ForeignKey("ArticleId")]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
