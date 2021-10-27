using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIOData.Models
{
    [Table("Route")]
    public class Route
    {
        [Key]
        [Column("CallSign")]
        [DataType("nvarchar(255)")]
        public string CallSign { get; set; }

        //[ForeignKey("FK_Route_FromAirpo_65370702")]
        [Column("FromAirport")]
        [DataType("nvarchar(255)")]
        public string FromAirport { get; set; }

        //[ForeignKey("FK_Route_ToAirport_662B2B3B")]
        [Column("ToAirport")]
        [DataType("nvarchar(255)")]
        public string ToAirport { get; set; }

        [ForeignKey("FromAirport")]
        public Airport FromAirportRef { get; set; }

        [ForeignKey("ToAirport")]
        public Airport ToAirportRef { get; set; }

        [Column("Passangers")]
        [DataType("int")]
        public int Passangers { get; set; }
    }
}
