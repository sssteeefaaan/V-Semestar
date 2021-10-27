using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    [Table("Poen")]
    public class Poen
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Vrednost")]
        public int Vrednost { get; set; }
        [ForeignKey("IgracID")]
        public int IgracID { get; set; }
    }
}