using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Primer1.Models
{
    [Table("ZooVrt")]
    public class Vrt
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Naziv")]
        [MaxLength(255)]
        //[DataType(DataType.Text)]
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