using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backEnd.Models
{
    [Table("Video Klub")]
    public class VideoKlub
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv { get; set; }
        public virtual List<Polica> Police { get; set; }
    }
}