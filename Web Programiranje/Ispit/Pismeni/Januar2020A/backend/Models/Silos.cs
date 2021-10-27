using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Silos")]
    public class Silos
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Oznaka")]
        [MaxLength(255)]
        public string Oznaka { get; set; }

        [Column("Kapacitet")]
        public int Kapacitet { get; set; }
        [Column("Treutna Količina")]
        public int TrenutnaKolicina { get; set; }

        [JsonIgnore]
        [Column("Fabrika")]
        public Fabrika Fabrika { get; set; }
    }
}