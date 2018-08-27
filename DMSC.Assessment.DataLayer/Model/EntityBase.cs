namespace DMSC.Assessment.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }   
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
