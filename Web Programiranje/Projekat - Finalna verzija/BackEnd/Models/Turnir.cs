using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Turnir")]
    public class Turnir
    {
        [Key]
        [Column("ID")]
        [DataType("integer")]
        public int ID { get; set; }

        [Column("Naziv")]
        [DataType("nvarchar(100)")]
        [MaxLength(100)]
        [Required]
        public string Naziv { get; set; }

        [Column("MaxDisciplina")]
        [DataType("smallint")]
        [Required]
        public int MaxDisciplina { get; set; }
    }
}