using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("Igrac")]
    public class Igrac
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [ForeignKey("MecID")]
        public int MecID { get; set; }
        [Column("Ime")]
        public string Ime { get; set; }
        [Column("Godine")]
        public int Godine { get; set; }
        [Column("ATP")]
        public int ATP { get; set; }
        [Column("Slika")]
        public string Slika { get; set; }
        public virtual List<Poen> Poeni { get; set; }
    }
}