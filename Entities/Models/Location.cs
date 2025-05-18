using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        [MaxLength(40)]
        public string LocationAddress { get; set; }

        [MaxLength(150)]
        public string WarehouseName { get; set; }

        [MaxLength(80)]
        public string LocationType { get; set; }

        public float Capacity { get; set; }

        public float UsedCapacity { get; set; }

        [MaxLength(80)]
        public string LocationStatus { get; set; }

        public int BlockExplanationId { get; set; }

        public string Explanation { get; set; }
    }

}
