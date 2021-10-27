using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreciCas.Models
{
    [Table("ZooVrt")]
    public class Vrt
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv { get; set; }

        [Column("Kapacitet")]
        public int Kapacitet { get; set; }

        [Column("N")]
        public int N { get; set; }

        [Column("M")]
        public int M { get; set; }

        public virtual List<Lokacija> Lokacije { get; set; }
    }
}
