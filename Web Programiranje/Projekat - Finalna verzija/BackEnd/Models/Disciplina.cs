using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Disciplina")]
    public class Disciplina
    {
        [Key]
        [Column("ID")]
        [DataType("integer")]
        public int ID { get; set; }

        [Column("TurnirID")]
        [DataType("integer")]
        [Required]
        public int TurnirID { get; set; }

        [Column("Naziv")]
        [DataType("nvarchar(100)")]
        [MaxLength(100)]
        [Required]
        public string Naziv { get; set; }

        [Column("Lokacija")]
        [DataType("nvarchar(100)")]
        [MaxLength(100)]
        [Required]
        public string Lokacija { get; set; }

        [Column("Maksimalni_Broj_Učesnika")]
        [DataType("smallint")]
        [Required]
        public int MaxUcesnici { get; set; }

        [Column("Pobednik")]
        [DataType("integer")]
        [AllowNull]
        public System.Nullable<int> PobednikID { get; set; }
    }
}