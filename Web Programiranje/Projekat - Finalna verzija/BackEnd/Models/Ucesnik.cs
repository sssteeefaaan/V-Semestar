using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Server.Models
{
    [Table("Učesnik")]
    public class Ucesnik
    {
        [Key]
        [Column("ID")]
        [DataType("integer")]
        public int ID { get; set; }

        [Column("DisciplinaID")]
        [DataType("integer")]
        [Required]
        public int DisciplinaID { get; set; }

        [Column("TurnirID")]
        [DataType("integer")]
        [Required]
        public int TurnirID { get; set; }

        [Column("Ime")]
        [DataType("nvarchar(50)")]
        [MaxLength(50)]
        [Required]
        public string Ime { get; set; }

        [Column("Prezime")]
        [DataType("nvarchar(50)")]
        [MaxLength(50)]
        [Required]
        public string Prezime { get; set; }

        [Column("Brzina")]
        [DataType("smallint")]
        [Required]
        public int Brzina { get; set; }

        [Column("Rang")]
        [DataType("smallint")]
        [AllowNull]
        public System.Nullable<int> Rang { get; set; }

        [Column("Pozicija")]
        [DataType("smallint")]
        [AllowNull]
        public System.Nullable<int> Pozicija { get; set; }

        [Column("Selected")]
        [DataType("boolean")]
        [AllowNull]
        public System.Nullable<bool> Selected { get; set; }

        [Column("Compete")]
        [DataType("boolean")]
        [AllowNull]
        public System.Nullable<bool> Compete { get; set; }
    }
}