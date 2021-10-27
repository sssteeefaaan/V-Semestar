using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Polica")]
    public class Polica
    {
        [Key]
        [Column("Video Klub ID")]
        public int VideoKlubID { get; set; }
        [Key]
        [Column("Oznaka")]
        public string Oznaka { get; set; }
        [Column("Boja")]
        public string Boja { get; set; }
        [Column("Max")]
        public int Max { get; set; }
        [Column("Curr")]
        public int Curr { get; set; }
        [JsonIgnore]
        public VideoKlub VideoKlub { get; set; }

    }
}