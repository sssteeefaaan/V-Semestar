using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("Video Klub")]
    public class VideoKlub
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Naziv")]
        public string Naziv { get; set; }
        [Column("Police")]
        public virtual List<Polica> Police { get; set; } = new List<Polica>();
    }
}