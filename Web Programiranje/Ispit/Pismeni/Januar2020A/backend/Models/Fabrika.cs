using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Fabrika")]
    public class Fabrika
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv { get; set; }

        public virtual List<Silos> Silosi { get; set; }
    }
}