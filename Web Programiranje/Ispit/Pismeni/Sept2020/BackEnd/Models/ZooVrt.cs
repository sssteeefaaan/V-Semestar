using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Zoo Vrt")]
    public class ZooVrt
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Naziv")]
        public string Naziv { get; set; }
        [Column("N")]
        public int N { get; set; }
        [Column("M")]
        public int M { get; set; }
        [Column("Max")]
        public int Max { get; set; }
        [Column("Tipovi Stanista")]
        public string[] TipoviStanista { get; set; }
        [Column("Boje Stanista")]
        public string[] BojeStanista { get; set; }
        public virtual List<Staniste> Stanista { get; set; }
    }
}