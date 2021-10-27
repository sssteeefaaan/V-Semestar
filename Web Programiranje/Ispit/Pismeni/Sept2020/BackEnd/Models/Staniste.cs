using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Stanište")]
    public class Staniste
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [ForeignKey("ZooVrtID")]
        public int ZooVrtID { get; set; }
        [Column("Vrsta")]
        public string Vrsta { get; set; }
        [Column("Boja")]
        public string Boja { get; set; }
        [Column("Max")]
        public int Max { get; set; }
        [Column("Trenutno")]
        public int Trenutno { get; set; }
    }
}