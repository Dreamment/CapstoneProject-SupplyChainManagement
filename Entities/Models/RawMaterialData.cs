using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Raw_Material_Data")]
    public class RawMaterialData
    {
        [Key]
        [MaxLength(40)]
        public string Company_Barcode { get; set; }

        [MaxLength(40)]
        public string Old_Barcode { get; set; }

        [MaxLength(80)]
        public string Brand { get; set; }

        [MaxLength(80)]
        public string Fabric_Composition { get; set; }

        [MaxLength(80)]
        public string Color { get; set; }

        public float Amount { get; set; }

        [MaxLength(80)]
        public string Unit { get; set; }

        public float Price { get; set; }
    }

}
