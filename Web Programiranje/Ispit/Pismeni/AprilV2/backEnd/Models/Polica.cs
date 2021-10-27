using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backEnd.Models
{
    [Table("Polica")]
    public class Polica
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Oznaka")]
        [MaxLength(255)]
        public string Oznaka { get; set; }
        [Column("Maksimalni Broj DVD-ova")]
        public int Max { get; set; }
        [Column("Trenutni Broj DVD-ova")]
        public int Current { get; set; }
        [ForeignKey("VideoKlubID")]
        public int VideoKlubID { get; set; }
    }
}