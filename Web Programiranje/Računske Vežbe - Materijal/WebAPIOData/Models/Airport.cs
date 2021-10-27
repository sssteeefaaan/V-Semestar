using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIOData.Models
{
    [Table("Airport")]
    public class Airport
    {
        [Key]
        [Column("Code")]
        [DataType("nvarchar(255)")]
        [MaxLength(255)]
        public string Code { get; set; }

        [Column("Name")]
        [DataType("nvarchar(255)")]
        public string Name { get; set; }

        [Column("City")]
        [DataType("nvarchar(255)")]
        public string City { get; set; }

        [Column("State")]
        [DataType("nvarchar(255)")]
        public string State { get; set; }

        [Column("Country")]
        [DataType("nvarchar(255)")]
        public string Country { get; set; }

        [Column("Elevation")]
        [DataType("int")]
        public int Elevation { get; set; }

        [Column("Lat")]
        [DataType("float")]
        public double Latitude { get; set; }

        [Column("Lon")]
        [DataType("float")]
        public double Longitude { get; set; }


        // public virtual List<Route> Rute { get; set; }
    }
}
