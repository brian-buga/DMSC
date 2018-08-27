namespace DMSC.Assessment.Backoffice.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ArticleModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        [StringLength(3000)]
        public string Content { get; set; }
        public bool Active { get; set; }
        public string Author { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Published { get; set; }
        public int Likes { get; set; }
        public bool IsSuccess { get; set; }
    }
}
