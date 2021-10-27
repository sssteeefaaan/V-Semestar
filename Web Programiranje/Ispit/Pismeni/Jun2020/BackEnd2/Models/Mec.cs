using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("Mec")]
    public class Mec
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Lokacija")]
        public string Lokacija { get; set; }
        [Column("Vreme")]
        public DateTime Vreme { get; set; }
        [Column("Maksimalni broj setova")]
        public int Max { get; set; }
        public virtual List<Igrac> Igraci { get; set; }
    }
}