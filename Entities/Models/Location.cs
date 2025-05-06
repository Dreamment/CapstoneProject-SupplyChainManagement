using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Location_ID { get; set; }

        [MaxLength(40)]
        public string Location_Address { get; set; }

        [MaxLength(150)]
        public string Warehouse_Name { get; set; }

        [MaxLength(80)]
        public string Location_Type { get; set; }

        public float Capacity { get; set; }

        public float Used_Capacity { get; set; }

        [MaxLength(80)]
        public string Location_Status { get; set; }

        public int Block_Explanation_ID { get; set; }

        public string Explanation { get; set; }
    }

}
